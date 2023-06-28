using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesJSON
{
    internal class QuotesData
    {
        public Quote[] quotes { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }

        

        public void Display()
        {
            foreach (Quote quote in quotes)
            {
                Console.WriteLine(quote);
                Console.WriteLine(new String('-', 100));
            }
        }
    }

    internal class Quote
    {
        public int id { get; set; }
        public string quote { get; set; }
        public string author { get; set; }

        public override string ToString()
        {
            return $"id: {id}\n" +
                $"quote: {quote}\n" +
                $"author: {author}\n";
        }

    }
}
