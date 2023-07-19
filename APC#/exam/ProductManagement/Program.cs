// See https://aka.ms/new-console-template for more information

using ProductManagement.Controllers;
using ProductManagement.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var productController = new ProductController();
        bool isExit = false;

        while (!isExit)
        {
            Console.Write("Press any key to continue: ");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n======== Product Mangement ========" +
                            "\n1. Add new product" +
                            "\n2. Display all products" +
                            "\n3. Delete a product" +
                            "\n4. Exit");

            Console.Write("Enter your selection: ");
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("======== Add new product ========");
                    Console.Write("Enter product ID: ");
                    string productId = Console.ReadLine();
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter price: ");
                    try
                    {
                        double price = Double.Parse(Console.ReadLine());
                        productController.Add(new Product (productId, name, price));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Add product failed: Invalid price number");
                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("======== Display all products ========");
                    productController.Display();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("======== Delete a product ========");
                    Console.Write("Enter product ID to delete: ");
                    string productIdToDelete = Console.ReadLine();
                    productController.Delete(productIdToDelete);
                    break;
                case "4":
                    Console.WriteLine("Exit the program................");
                    isExit = true;
                    break;
                default:
                    Console.WriteLine("Invalid selection, try again");
                    break;
            }
        }
    }
}
