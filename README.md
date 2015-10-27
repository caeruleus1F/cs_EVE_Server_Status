# cs_EVE_Server_Status

http://imgur.com/nCBjfRC - Screenshot

Does the same thing as its Visual Basic counterpart, but has the added benefit of not being Visual Basic (sorry, VB).

On button-click, makes a call to one of the EVE Online API endpoints that caches Tranquility server status and population data. 

The returned document contains information as to whether the server is online, how many players are logged in, and the cache expiration period.

The program displays whether the server is online, how many players are connected to the Tranquility (TQ) server, the amount and percent of change since the last API call, the 30-ST difference and percent, and the next time an API call will be made. The program itself operates on a timer after the first button click event. Data time and player count are stored in a local ccp_server.csv file in CSV format.

The 30-ST is the newest feature added to the program. This program has been running for a long enough time that I can do some statistical wizardry with the data. 30-ST says, "With respect to the latest datapoint, take all datapoints fromt he past 30 days, filter out the ones that fall on different days of the week, and filter those remaining out that are not within 5 minutes, plus or minus. Now, average them to find out the typical player population for this point in time for the last 30 days. Display the integer and percent difference." This information reveals how much higher or lower current server population is compared to similar points in time.
