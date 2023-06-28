using QuotesJSON.controller;
using System.Text.Json;

namespace QuotesJSON
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            string url = "https://dummyjson.com/quotes";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response
                    QuotesData? quotesData = JsonSerializer.Deserialize<QuotesData>(responBody);

                    // Access and process the JSON data as needed
                    Quote[] quotes = quotesData.quotes;
                    QuoteController.AddQuotes(quotes);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
    }
}