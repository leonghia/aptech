using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace ProductsJSON
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            string url = "https://dummyjson.com/products";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response
                    ProductsData? productsData = JsonSerializer.Deserialize<ProductsData>(responBody);

                    // Access and process the JSON data as needed
                    productsData.DisplayProducts();
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                
            }
        }
    }
}