using CommentsJSON.util;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentsJSON.controller
{
    internal static class UserController
    {

        public static void AddUsers(LinkedList<User> users)
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();

                foreach (User user in users)
                {
                    command = new MySqlCommand("sp_add_user", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_param", user.id);
                    command.Parameters.AddWithValue("@username_param", user.username);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add user successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Add user failed");
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
