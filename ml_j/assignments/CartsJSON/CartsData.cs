using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartsJSON
{
    internal class CartsData
    {

        public Cart[] carts { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
        
        public Product[] GetProducts()
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>();
            foreach (Cart cart in carts)
            {
                foreach (Product product in cart.products)
                {
                    if (!products.ContainsKey(product.id))
                    {
                        products.Add(product.id, product);
                    }
                }
            }
            return products.Values.ToArray();
        }
    }

    internal class Cart
    {
        public int id { get; set; }
        public Product[] products { get; set; }
        public decimal total { get; set; }
        public decimal discountedTotal { get; set; }
        public int userId { get; set; }
        public int totalProducts { get; set; }
        public int totalQuantity { get; set; }



        public override string ToString()
        {
            string products = string.Empty;
            foreach (Product product in this.products)
            {
                products += product.ToString();

            }
            return $"id: {id}\n" +
                $"products: \n" +
                $"{products}\n" +
                $"total: {total}\n" +
                $"discountedTotal: {discountedTotal}\n" +
                $"userId: {userId}\n" +
                $"totalProducts: {totalProducts}\n" +
                $"totalQuantity: {totalQuantity}\n";
        }
    }
    

    internal class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public int total { get; set; }
        public decimal discountPercentage { get; set; }
        public decimal discountedPrice { get; set; }

        public override string ToString()
        {
            return $"\t\tid: {id}\n" +
                $"\t\ttitle: {title}\n" +
                $"\t\tprice: {price}\n" +
                $"\t\tquantity: {quantity}\n" +
                $"\t\ttotal: {total}\n" +
                $"\t\tdiscountePercentage: {discountPercentage}\n" +
                $"\t\tdiscountedPrice: {discountedPrice}\n" +
                $"\n";
        }
    }
}
