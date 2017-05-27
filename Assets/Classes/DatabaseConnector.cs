using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.SqliteClient;
using System.Data;
using System.IO;

namespace Assets.Classes
{
    class DatabaseConnector
    {
        static string path = Directory.GetCurrentDirectory();
        static string conn = "URI=file:" + path + "\\Assets\\Plugins\\Database.db";
        public List<string> connect()
        {
            List<string> usernames = new List<string> {};
            IDbConnection dbconn = (IDbConnection) new SqliteConnection(conn);
            dbconn.Open();
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT username from Players ";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                string username = reader.GetString(0);
                usernames.Add(username);
                
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
            //usernames.Add(conn);
            return usernames;
        }
        
    }

}
