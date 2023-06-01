using MySqlConnector;
using PostsJSON.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PostsJSON.controller
{
    internal static class PostController
    {

        private static int GetTagIdByName(Dictionary<int, string> tags, string name)
        {
            foreach (KeyValuePair<int, string> pair in  tags)
            {
                if (EqualityComparer<string>.Default.Equals(pair.Value, name))
                {
                    return pair.Key;
                }
            }
            throw new KeyNotFoundException("The key is not found for the specified value.");
        }

        public static void AddPosts(Post[] posts)
        {
            MySqlConnection conn = null;
            MySqlCommand command_add_post = null;
            MySqlCommand command_add_post_tag = null;
            MySqlCommand command_get_tags = null;
            Dictionary<int, string> tags = new Dictionary<int, string>();

            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();

                command_get_tags = new MySqlCommand("sp_get_tags", conn);
                command_get_tags.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader reader = command_get_tags.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        tags.Add(id, name);
                    }
                }

                

                

                foreach (Post post in posts)
                {
                    command_add_post = new MySqlCommand("sp_add_post", conn);
                    command_add_post.CommandType = CommandType.StoredProcedure;
                    command_add_post.Parameters.AddWithValue("@id_param", post.id);
                    command_add_post.Parameters.AddWithValue("@title_param", post.title);
                    command_add_post.Parameters.AddWithValue("@body_param", post.body);
                    command_add_post.Parameters.AddWithValue("@user_id_param", post.userId);
                    command_add_post.Parameters.AddWithValue("@reactions_param", post.reactions);

                    if (command_add_post.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add post successfully");
                    }

                    foreach (string tag_name in post.tags)
                    {
                        command_add_post_tag = new MySqlCommand("sp_add_post_tag", conn);
                        command_add_post_tag.CommandType = CommandType.StoredProcedure;
                        command_add_post_tag.Parameters.AddWithValue("@post_id_param", post.id);
                        int tag_id = GetTagIdByName(tags, tag_name);
                        command_add_post_tag.Parameters.AddWithValue("@tag_id_param", tag_id);

                        if (command_add_post_tag.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine("Add post - tag successfully");
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
