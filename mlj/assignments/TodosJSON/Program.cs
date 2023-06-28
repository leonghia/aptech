using System.Text.Json;
using TodosJSON.controller;

namespace TodosJSON
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            string url = "https://dummyjson.com/todos";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response
                    TodosData? todosData = JsonSerializer.Deserialize<TodosData>(responBody);

                    // Access and process the JSON data as needed
                    Todo[] todos = todosData.todos;
                    TodoController.AddTodos(todos);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
    }
}