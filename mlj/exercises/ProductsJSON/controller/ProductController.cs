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
    internal static class ProductController
    {
        private static int GetCategoryIdByName(Dictionary<int, string> categories, string name)
        {
            foreach (KeyValuePair<int, string> kvp in categories)
            {
                if (EqualityComparer<string>.Default.Equals(kvp.Value, name))
                {
                    return kvp.Key;
                }
            }
            throw new KeyNotFoundException("The id is not found for the specified category name");
        }

        public static void AddProducts(Product[] products)
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;
            MySqlCommand command_get_categories = null;
            Dictionary<int, string> categories = new Dictionary<int, string>();

            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();

                command_get_categories = new MySqlCommand("sp_get_categories", conn);
                command_get_categories.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader reader = command_get_categories.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        categories.Add(id, name);
                    }
                }

                foreach (Product product in products)
                {
                    command = new MySqlCommand("sp_add_product", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_param", product.id);
                    command.Parameters.AddWithValue("@title_param", product.title);
                    command.Parameters.AddWithValue("@description_param", product.description);
                    command.Parameters.AddWithValue("@price_param", product.price);
                    command.Parameters.AddWithValue("@discount_percentage_param", product.discountPercentage);
                    command.Parameters.AddWithValue("@rating_param", product.rating);
                    command.Parameters.AddWithValue("@stock_param", product.stock);
                    command.Parameters.AddWithValue("@brand_param", product.brand);
                    int category_id = GetCategoryIdByName(categories, product.category);
                    command.Parameters.AddWithValue("@category_id_param", category_id);
                    command.Parameters.AddWithValue("@thumbnail_param", product.thumbnail);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add product successfully");
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
