using CommentsJSON.util;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentsJSON.controller
{
    internal static class CommentController
    {
        public static void AddComments(Comment[] comments)
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();

                foreach (Comment comment in comments)
                {
                    command = new MySqlCommand("sp_add_comment", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_param", comment.id);
                    command.Parameters.AddWithValue("@body_param", comment.body);
                    command.Parameters.AddWithValue("@post_id_param", comment.postId);
                    command.Parameters.AddWithValue("@user_id_param", comment.user.id);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add comment successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Add comment failed");
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
