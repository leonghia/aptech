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
    internal static class CartController
    {
        public static void AddCarts(Cart[] carts)
        {
            MySqlConnection conn = null;
            MySqlCommand command_add_cart = null;
            MySqlCommand command_add_cart_product = null;

            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();
                
                foreach (Cart cart in carts)
                {
                    command_add_cart = new MySqlCommand("sp_add_cart", conn);
                    command_add_cart.CommandType = CommandType.StoredProcedure;

                    command_add_cart.Parameters.AddWithValue("@id_param", cart.id);
                    command_add_cart.Parameters.AddWithValue("@total_param", cart.total);
                    command_add_cart.Parameters.AddWithValue("@discounted_total_param", cart.discountedTotal);
                    command_add_cart.Parameters.AddWithValue("@user_id_param", cart.userId);
                    command_add_cart.Parameters.AddWithValue("@total_products_param", cart.totalProducts);
                    command_add_cart.Parameters.AddWithValue("@total_quantity_param", cart.totalQuantity);

                    if (command_add_cart.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add cart successfully");
                    }

                    foreach (Product product in cart.products)
                    {
                        command_add_cart_product = new MySqlCommand("sp_add_cart_product", conn);
                        command_add_cart_product.CommandType = CommandType.StoredProcedure;

                        command_add_cart_product.Parameters.AddWithValue("@cart_id_param", cart.id);
                        command_add_cart_product.Parameters.AddWithValue("@product_id_param", product.id);

                        if (command_add_cart_product.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine("Add cart - product successfully");
                        }
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
