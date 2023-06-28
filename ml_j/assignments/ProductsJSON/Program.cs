using ProductsJSON.controller;
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
                    HashSet<string> categories = productsData.GetCategories();
                    CategoryController.AddCategories(categories);

                    Product[] products = productsData.products;
                    ProductController.AddProducts(products);

                    LinkedList<Image> images = productsData.GetImages();
                    ImageController.AddImages(images);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
    }
}