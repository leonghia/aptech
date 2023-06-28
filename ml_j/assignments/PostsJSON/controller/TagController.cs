using MySqlConnector;
using PostsJSON.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsJSON.controller
{
    internal static class TagController
    {
        public static void AddTags(LinkedList<Tag> tags)
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();

                foreach (Tag tag in tags)
                {
                    command = new MySqlCommand("sp_add_tag", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name_param", tag.name);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add tag successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Add tag failed");
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
