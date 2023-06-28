using MySqlConnector;
using QuotesJSON.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuotesJSON.controller
{
    internal static class QuoteController
    {

        public static void AddQuotes(Quote[] quotes)
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();

                foreach (Quote q in quotes)
                {
                    command = new MySqlCommand("sp_add_quote", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_param", q.id);
                    command.Parameters.AddWithValue("@quote_param", q.quote);
                    command.Parameters.AddWithValue("@author_param", q.author);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add quote successfully");
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
