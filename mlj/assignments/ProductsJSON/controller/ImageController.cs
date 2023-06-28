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
    internal static class ImageController
    {
        public static void AddImages(LinkedList<Image> images)
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;
            
            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();

                foreach (Image image in images)
                {
                    command = new MySqlCommand("sp_add_image", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@src_param", image.src);
                    command.Parameters.AddWithValue("@product_id_param", image.product_id);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add image successfully");
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
