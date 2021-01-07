using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MonopolyCash.Data;
using System.Data.SqlClient;

namespace MonopolyCash.Hubs
{
    public class GameHub : Hub
    {
        string server = "monopolycash.database.windows.net";
        string user = "admin123";
        string pwd = "Koby8781";
        string db = "monopoly";

        public async Task createRoom(String gameKey, String playerName, int startingCash)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameKey);
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = server,
                    UserID = user,
                    Password = pwd,
                    InitialCatalog = db
                };

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    int playerID = (playerName + gameKey).GetHashCode();
                    int gameID = gameKey.GetHashCode();
                    String sql = "INSERT INTO playerData VALUES ("+playerID+", '" + playerName + "', " + gameID + ", " + startingCash + ", 0, 1)";
                    SqlCommand command = new SqlCommand(sql, conn);
                    await command.ExecuteNonQueryAsync();

                    String sql1 = "INSERT INTO gameData VALUES (" + gameID + ", '" +gameKey+"')";
                    SqlCommand command1 = new SqlCommand(sql1, conn);
                    await command1.ExecuteNonQueryAsync();
                    conn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public async Task joinRoom(String gameKey, String playerName, int startingCash)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = server,
                    UserID = user,
                    Password = pwd,
                    InitialCatalog = db,
                    MultipleActiveResultSets = true

                };

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    String sql_select = "SELECT * FROM gameData WHERE gameKey='" + gameKey + "'";
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql_select, conn);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows) {
                        int playerID = (playerName+gameKey).GetHashCode();
                        int gameID = gameKey.GetHashCode();
                        String sql = "INSERT INTO playerData VALUES (" + playerID + ", '" + playerName + "', " + gameID + ", " + startingCash + ", 0, 0)";
                        SqlCommand command1 = new SqlCommand(sql, conn);
                        await command1.ExecuteNonQueryAsync();
                        String[] data = { playerName, gameKey };
                        await Clients.All.SendAsync("joinedRoom", data);
                    }
                    else
                    {
                     //insert code for redirecting if the incorrect key is entered
                    }
                    conn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public async Task updateStatus(int playerID)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = server,
                    UserID = user,
                    Password = pwd,
                    InitialCatalog = db,
                    MultipleActiveResultSets = true
                };

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    String sql = "UPDATE playerData SET status = status ^ 1 WHERE playerID='"+playerID+"'";
                    SqlCommand command = new SqlCommand(sql, conn);
                    await command.ExecuteNonQueryAsync();

                    String sql_select = "SELECT gameKey from gameData WHERE gameID = (SELECT gameID FROM playerData WHERE playerID='" + playerID + "')";
                    SqlCommand command1 = new SqlCommand(sql_select, conn);
                    SqlDataReader reader = await command1.ExecuteReaderAsync();
                    String gameKey="";
                    while (await reader.ReadAsync())
                    {
                        gameKey = reader.GetString(0);
                    }
                    await Clients.All.SendAsync("ready", gameKey);
                    conn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public async Task<Dictionary<string,string>> readStatus(int playerID)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = server,
                    UserID = user,
                    Password = pwd,
                    InitialCatalog = db
                };

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    String sql_select = "SELECT player,status from playerData WHERE gameID = (SELECT gameID FROM playerData WHERE playerID='" + playerID + "')";
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql_select, conn);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    Dictionary<string, string> playerData = new Dictionary<string, string>();
                    while (await reader.ReadAsync())
                    {
                        String name = reader.GetString(0);
                        bool status = reader.GetBoolean(1);

                        if (status)
                        {
                            playerData.Add(name, "Ready");
                        }
                        else
                        {
                            playerData.Add(name, "Not ready");
                        }
                    }
                    conn.Close();
                    return await Task.FromResult(playerData);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                Dictionary<string, string> playerData = new Dictionary<string, string>();
                return await Task.FromResult(playerData);
            }
        }

        public async Task<Object[]> getPlayerData(int playerID)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = server,
                    UserID = user,
                    Password = pwd,
                    InitialCatalog = db,
                    MultipleActiveResultSets = true
                };

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    String sql_select = "SELECT * from playerData WHERE playerID ='" + playerID + "'";
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql_select, conn);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    Object[] playerData = new Object[5];
                    while (await reader.ReadAsync())
                    {
                        playerData[0] = reader.GetString(1);
                        playerData[1] = reader.GetInt32(2);
                        playerData[2] = reader.GetInt32(3);
                        playerData[3] = reader.GetBoolean(5);
                    }
                    String sql_select1 = "SELECT gameKey from gameData WHERE gameID = (SELECT gameID FROM playerData WHERE playerID='" + playerID + "')";
                    SqlCommand command1 = new SqlCommand(sql_select1, conn);
                    SqlDataReader reader1 = await command1.ExecuteReaderAsync();
                    while (await reader1.ReadAsync())
                    {
                        playerData[4] = reader1.GetString(0);
                    }
                    conn.Close();
                    return await Task.FromResult(playerData);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                Object[] playerData = new Object[4];
                return await Task.FromResult(playerData);
            }
        }

        public async Task pay(int playerID, int recName, int amount, int reason)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = server,
                    UserID = user,
                    Password = pwd,
                    InitialCatalog = db,
                    MultipleActiveResultSets = true
                };

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    Object[] data = await getPlayerData(playerID);
                    int gameID = Int32.Parse(data[1].ToString());

                    if (Int32.Parse(data[2].ToString()) < amount)
                    {
                        await Clients.All.SendAsync("invalidfunds", playerID);
                    }
                    else 
                    {
                        String sql = "UPDATE playerData SET balance = balance-" + amount + "WHERE playerID='" + playerID + "'";
                        SqlCommand command = new SqlCommand(sql, conn);
                        await command.ExecuteNonQueryAsync();

                        String sql1 = "UPDATE playerData SET balance = balance+" + amount + "WHERE player='" + recName + "' and gameID='" + gameID + "'";
                        SqlCommand command1 = new SqlCommand(sql1, conn);
                        await command1.ExecuteNonQueryAsync();

                        String sql2 = "INSERT INTO transactions VALUES ("+gameID+",'"+data[0].ToString()+"','"+recName+"',"+reason+","+amount+")";
                        SqlCommand command2 = new SqlCommand(sql2, conn);
                        await command2.ExecuteNonQueryAsync();

                        Object[] dataSend = {data[0],recName,amount,gameID};
                        await Clients.All.SendAsync("transaction", dataSend);
                    }
                    conn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public async Task payFromBank(int playerID, int amount, int reason)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = server,
                    UserID = user,
                    Password = pwd,
                    InitialCatalog = db,
                    MultipleActiveResultSets = true
                };

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    Object[] data = await getPlayerData(playerID);
                    int gameID = Int32.Parse(data[1].ToString());

                    String sql = "UPDATE playerData SET balance = balance+" + amount + "WHERE playerID='" + playerID + "'";
                    SqlCommand command = new SqlCommand(sql, conn);
                    await command.ExecuteNonQueryAsync();

                    String sql2 = "INSERT INTO transactions VALUES (" + gameID + ",'Bank','" + data[0].ToString() + "'," + reason + "," + amount + ")";
                    SqlCommand command2 = new SqlCommand(sql2, conn);
                    await command2.ExecuteNonQueryAsync();

                    Object[] dataSend = { "Bank", data[0], amount, gameID };
                    await Clients.All.SendAsync("transaction", dataSend);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
