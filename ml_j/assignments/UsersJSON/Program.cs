using System.Text.Json;
using UsersJSON.controller;

namespace UsersJSON
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            bool isExit = false;
            while (!isExit)
            {
                
                Console.WriteLine();
                Console.WriteLine(new String('=', 10) + " Welcome to Users Program " + new String('=', 10));
                Console.WriteLine("1. Import data from API to DB");
                Console.WriteLine("2. Clear all data in DB");               
                Console.WriteLine("3. Exit");
                Console.Write("Enter your selection: ");

                

                switch (Console.ReadLine())
                {
                    case "1":
                        
                        Console.WriteLine();
                        Console.WriteLine(new String('=', 10) + " Import data from API to DB " + new String('=', 10));
                        Console.Write("Enter API: ");
                        string url = Console.ReadLine();
                        UsersData? usersData = await GetUsersData(url);
                        if (usersData != null)
                        {
                            DataController.ImportData(usersData);
                        }
                        break;
                    case "2":
                        
                        Console.WriteLine();
                        Console.WriteLine(new String('=', 10) + " Clear all data in DB " + new String('=', 10));
                        Console.WriteLine("Clearing" + new string('-', 30));
                        DataController.ClearData();
                        break;
                    case "3":
                        
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            }
            
        }

        private static async Task<UsersData?> GetUsersData(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response
                    UsersData? usersData = JsonSerializer.Deserialize<UsersData>(responBody);

                    return usersData;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }
    }
}