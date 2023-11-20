using System.Text.Json.Serialization;

namespace AspNetMvc.Models
{
    public class ProductRequestParams : RequestParams
    {      
        public int? Category { get; set; }      
        public string? Price { get; set; }       
        public string? Stock { get; set; }       
        public string? SalesPerDay { get; set; }       
        public string? SalesPerMonth { get; set; }        
        public int? Rating { get; set; }
        public string? Sales { get; set; }
        public string? Revenue { get; set; }     
    }
}
