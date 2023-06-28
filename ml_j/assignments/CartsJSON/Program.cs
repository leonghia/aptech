using CartsJSON.controller;
using System.Text.Json;

namespace CartsJSON
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            string url = "https://dummyjson.com/carts";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response
                    CartsData? cartsData = JsonSerializer.Deserialize<CartsData>(responBody);

                    // Access and process the JSON data as needed
                    Product[] products = cartsData.GetProducts();
                    ProductController.AddProducts(products);

                    Cart[] carts = cartsData.carts;
                    CartController.AddCarts(carts);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
    }
}