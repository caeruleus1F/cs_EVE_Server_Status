namespace cs_EVE_Server_Status
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbStatus = new System.Windows.Forms.TextBox();
            this.txbPlayers = new System.Windows.Forms.TextBox();
            this.txbSinceLast = new System.Windows.Forms.TextBox();
            this.txb30ST = new System.Windows.Forms.TextBox();
            this.txbNext = new System.Windows.Forms.TextBox();
            this.timerRequest = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(68, 142);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Players:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Since Last:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "30-ST:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Next:";
            // 
            // txbStatus
            // 
            this.txbStatus.Location = new System.Drawing.Point(78, 12);
            this.txbStatus.Name = "txbStatus";
            this.txbStatus.ReadOnly = true;
            this.txbStatus.Size = new System.Drawing.Size(100, 20);
            this.txbStatus.TabIndex = 7;
            // 
            // txbPlayers
            // 
            this.txbPlayers.Location = new System.Drawing.Point(78, 38);
            this.txbPlayers.Name = "txbPlayers";
            this.txbPlayers.ReadOnly = true;
            this.txbPlayers.Size = new System.Drawing.Size(100, 20);
            this.txbPlayers.TabIndex = 8;
            // 
            // txbSinceLast
            // 
            this.txbSinceLast.Location = new System.Drawing.Point(78, 64);
            this.txbSinceLast.Name = "txbSinceLast";
            this.txbSinceLast.ReadOnly = true;
            this.txbSinceLast.Size = new System.Drawing.Size(100, 20);
            this.txbSinceLast.TabIndex = 9;
            // 
            // txb30ST
            // 
            this.txb30ST.Location = new System.Drawing.Point(78, 90);
            this.txb30ST.Name = "txb30ST";
            this.txb30ST.ReadOnly = true;
            this.txb30ST.Size = new System.Drawing.Size(100, 20);
            this.txb30ST.TabIndex = 10;
            // 
            // txbNext
            // 
            this.txbNext.Location = new System.Drawing.Point(78, 116);
            this.txbNext.Name = "txbNext";
            this.txbNext.ReadOnly = true;
            this.txbNext.Size = new System.Drawing.Size(100, 20);
            this.txbNext.TabIndex = 11;
            // 
            // timerRequest
            // 
            this.timerRequest.Interval = 1000;
            this.timerRequest.Tick += new System.EventHandler(this.timerRequest_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 174);
            this.Controls.Add(this.txbNext);
            this.Controls.Add(this.txb30ST);
            this.Controls.Add(this.txbSinceLast);
            this.Controls.Add(this.txbPlayers);
            this.Controls.Add(this.txbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuery);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Server Status";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbStatus;
        private System.Windows.Forms.TextBox txbPlayers;
        private System.Windows.Forms.TextBox txbSinceLast;
        private System.Windows.Forms.TextBox txb30ST;
        private System.Windows.Forms.TextBox txbNext;
        private System.Windows.Forms.Timer timerRequest;
    }
}

