using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentsJSON.util
{
    internal static class DBConnection
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;port=3306;database=comments_db;uid=root;password=;";
            
            return new MySqlConnection(connectionString);
        }
    }
}
