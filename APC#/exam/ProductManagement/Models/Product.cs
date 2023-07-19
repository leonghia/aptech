namespace ProductManagement.Models;

public class Product
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string productId, string name, double price)
    {
        ProductId = productId;
        Name = name;
        Price = price;
    }
}
