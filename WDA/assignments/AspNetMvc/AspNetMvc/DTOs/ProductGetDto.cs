using AspNetMvc.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspNetMvc.DTOs
{
    public class ProductGetDto
    {
        
        public int Id { get; set; }
        
        public required string Name { get; set; }
       
        public string? Image { get; set; }

        public required decimal Price { get; set; }
        
        public string? Description { get; set; }
        
        public required CategoryGetDto Category { get; set; }
        
        public int Stock { get; set; }
       
        public double SalesPerDay { get; set; }
        
        public double SalesPerMonth { get; set; }
        
        public float Rating { get; set; }
       
        public int Sales { get; set; }
        
        public decimal Revenue { get; set; }

        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;
    }
}
