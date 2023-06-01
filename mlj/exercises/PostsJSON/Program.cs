using PostsJSON.controller;
using System.Text.Json;

namespace PostsJSON
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            string url = "https://dummyjson.com/posts";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response
                    PostsData? postsData = JsonSerializer.Deserialize<PostsData>(responBody);

                    // Access and process the JSON data as needed
                    LinkedList<Tag> tags = postsData.GetTags();
                    TagController.AddTags(tags);
                    Post[] posts = postsData.posts;
                    PostController.AddPosts(posts);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
    }
}