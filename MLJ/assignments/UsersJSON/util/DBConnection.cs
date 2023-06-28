using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersJSON.util
{
    internal static class DBConnection
    {

        public static MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;port=3306;database=users_db;uid=root;password=;";

            return new MySqlConnection(connectionString);
        }
    }
}
