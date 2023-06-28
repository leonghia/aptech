using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsJSON
{
    internal class ProductsData
    {
        public required Product[] products { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }


        

        public void DisplayProducts()
        {
            foreach (Product product in products)
            {
                Console.WriteLine(product.ToString());
                Console.WriteLine(new String('-', 200));
            }
        }

        public HashSet<string> GetCategories()
        {
            HashSet<string> categories = new HashSet<string>();
            foreach (Product product in products)
            {
                categories.Add(product.category);
            }
            return categories;
        }

        public LinkedList<Image> GetImages()
        {
            LinkedList<Image> images = new LinkedList<Image>();
            foreach (Product product in products)
            {
                foreach (string imageName in product.images)
                {
                    Image image = new Image(imageName, product.id);
                    images.AddLast(image);
                }
            }
            return images;
        }
    }

    internal class Product
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public decimal price { get; set; }
        public decimal discountPercentage { get; set; }
        public decimal rating { get; set; }
        public int stock { get; set; }
        public string? brand { get; set; }
        public string? category { get; set; }
        public string? thumbnail { get; set; }
        public required string[] images { get; set; }

        public override string? ToString()
        {
            string images = string.Empty;
            foreach (string image in this.images)
            {
                images += image;
                images += "\n\t\t";
            }

            return $"\tid: {id}\n" +
                $"\ttitle: {title}\n" +
                $"\tdescription: {description}\n" +
                $"\tprice: {price}\n" +
                $"\tdiscountPercentage: {discountPercentage}\n" +
                $"\trating: {rating}\n" +
                $"\tstock: {stock}\n" +
                $"\tbrand: {brand}\n" +
                $"\tcategory: {category}\n" +
                $"\tthumbnail: {thumbnail}\n" +
                $"\timages: {images}";
        }
    }

    internal class Image
    {
        public int id { get; set; }
        public string src { get; set; }
        public int product_id { get; set; }

        public Image(string src, int product_id)
        {
            this.src = src;
            this.product_id = product_id;
        }
    }

    
}
