using ProductManagement.Models;

namespace ProductManagement.Controllers;

public class ProductController
{
    private readonly List<Product> _products;

    public ProductController()
    {
        _products = new List<Product>();
    }

    public void Add(Product product)
    {
        try
        {
            _products.Add(product);
            Console.WriteLine("Add product successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Add product failed: " + ex.Message);
        }
    }

    public void Display()
    {
        Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|", "Product ID", "Product Name", "Price"));

        foreach (var p in _products)
        {
            Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|", p.ProductId, p.Name, p.Price));
        }
    }

    public void Delete(string id)
    {
        try
        {
            var result = _products.FirstOrDefault(p => p.ProductId == id);
            _products.Remove(result);
            Console.WriteLine("Delete product successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Delete product failed: " + ex.Message);
        }
    }
}
