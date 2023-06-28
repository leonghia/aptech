using CommentsJSON.controller;
using System.Text.Json;

namespace CommentsJSON
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            string url = "https://dummyjson.com/comments";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response
                    CommentsData? commentsData = JsonSerializer.Deserialize<CommentsData>(responBody);

                    // Access and process the JSON data as needed

                    //LinkedList<User> users = commentsData.GetUsers();
                    //UserController.AddUsers(users);

                    Comment[] comments = commentsData.comments;
                    CommentController.AddComments(comments);
                    
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
    }
}