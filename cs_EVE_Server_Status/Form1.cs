using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;

namespace cs_EVE_Server_Status
{
    public partial class Form1 : Form
    {
        XmlDocument _xmldoc = new XmlDocument();
        bool _server_online = false;
        int _online_players = 0;
        int _last_player_count = 0;
        DateTime _cached_until;
        DateTime _current_time;
        WebClient _web = new WebClient();

        public Form1()
        {
            InitializeComponent();
            _web.DownloadStringCompleted += ProcessServerResponse;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {

            try
            {
                _web.DownloadStringAsync(new Uri("https://api.eveonline.com/server/ServerStatus.xml.aspx/"));
            }
            catch (Exception ex)
            {
                txbPlayers.Text = "N/A";
                txbStatus.Text = "N/A";
            }
        }

        void ProcessServerResponse(object sender, DownloadStringCompletedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            _last_player_count = _online_players;
            _online_players = 0;
            int player_difference = 0;

            try
            {
                _xmldoc.LoadXml(e.Result);
                _current_time = DateTime.Parse(_xmldoc.SelectSingleNode("/eveapi/currentTime").InnerText);
                _cached_until = DateTime.Parse(_xmldoc.SelectSingleNode("/eveapi/cachedUntil").InnerText);
                _server_online = Convert.ToBoolean(_xmldoc.SelectSingleNode("/eveapi/result/serverOpen").InnerText);

                if (_server_online)
                {
                    // Status
                    txbStatus.Text = "Online";
                    txbStatus.BackColor = Color.LawnGreen;

                    // Players
                    _online_players = Convert.ToInt32(_xmldoc.SelectSingleNode("/eveapi/result/onlinePlayers").InnerText);
                    txbPlayers.Text = _online_players.ToString();

                    // Since Last
                    player_difference = _online_players - _last_player_count;
                    float pct_change = 100 * (float)_online_players / _last_player_count;
                    sb.Append(player_difference).Append(" ")
                        .Append(pct_change.ToString("N1"))
                        .Append("%");
                    txbSinceLast.Text = sb.ToString();
                    sb.Clear();

                    // 30-ST
                    DetermineRelativePlayerPopulation(player_difference);

                    // Next
                    txbNext.Text = _cached_until.ToLocalTime().AddSeconds(5).ToLongTimeString();

                    // Timer
                    int interval = Convert.ToInt32(_cached_until.Subtract(_current_time).TotalMilliseconds) + 5000;
                    timerRequest.Interval = interval;
                    timerRequest.Enabled = true;

                    // Write to ccp_server.csv
                    using (StreamWriter w = new StreamWriter("ccp_server.csv", true))
                    {
                        sb.Append(DateTime.Now.ToShortDateString())
                            .Append(" ")
                            .Append(DateTime.Now.ToLongTimeString())
                            .Append(",")
                            .Append(_online_players);
                        w.WriteLine(sb.ToString());
                        w.Close();
                        sb.Clear();
                    }
                }
                else
                {
                    txbStatus.Text = "Offline";
                    txbStatus.BackColor = Color.Red;
                }


            }
            catch (Exception ex)
            {
                txbStatus.Text = "Comm. Error";
            }
        }

        private void DetermineRelativePlayerPopulation(int player_difference)
        {
            List<string> lines = new List<string>();
            string line = null;
            DateTime now = DateTime.Now;
            DateTime lineDate;
            StringBuilder sb = new StringBuilder();
            int qualifying_player_total = 0;
            int average_now_player_count = 0;
            int difference_30_ST = 0;

            using (StreamReader r = new StreamReader("ccp_server.csv"))
            {
                r.ReadLine(); // discard first line, header

                while (!r.EndOfStream)
                {
                    line = r.ReadLine();
                    lineDate = DateTime.Parse(line.Split(',')[0]);

                    if (now.AddDays(-30) <= lineDate &&
                        now.DayOfWeek == lineDate.DayOfWeek &&
                        now.TimeOfDay.Add(TimeSpan.FromMinutes(-5)) <= lineDate.TimeOfDay &&
                        now.TimeOfDay.Add(TimeSpan.FromMinutes(5)) >= lineDate.TimeOfDay)
                    {
                        lines.Add(line);
                    }
                }

                r.Close();
            }

            foreach (string item in lines)
            {
                qualifying_player_total += Convert.ToInt32(item.Split(',')[1]);
            }

            average_now_player_count = Convert.ToInt32(qualifying_player_total / lines.Count);
            difference_30_ST = _online_players - average_now_player_count;
            float pct_difference = 100 * (float)_online_players / average_now_player_count;
            sb.Append(difference_30_ST)
                .Append(" ")
                .Append(pct_difference.ToString("N1"))
                .Append("%");
            txb30ST.Text = sb.ToString();

            sb.Clear();
            lines.Clear();
        }

        private void timerRequest_Tick(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
