using MySqlConnector;
using ProductsJSON.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProductsJSON.controller
{
    internal static class CategoryController
    {

        public static void AddCategories(HashSet<string> categories)
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();

                foreach (string category in categories)
                {
                    command = new MySqlCommand("sp_add_category", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name_param", category);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add category successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

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
