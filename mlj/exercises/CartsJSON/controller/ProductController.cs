using CartsJSON.util;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CartsJSON.controller
{
    internal static class ProductController
    {

        public static void AddProducts(Product[] products)
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();

                foreach (Product product in products)
                {
                    command = new MySqlCommand("sp_add_product", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_param", product.id);
                    command.Parameters.AddWithValue("@title_param", product.title);
                    command.Parameters.AddWithValue("@price_param", product.price);
                    command.Parameters.AddWithValue("@quantity_param", product.quantity);
                    command.Parameters.AddWithValue("@total_param", product.total);
                    command.Parameters.AddWithValue("@discount_percentage_param", product.discountPercentage);
                    command.Parameters.AddWithValue("@discounted_price_param", product.discountedPrice);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add product sucessfully");
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
