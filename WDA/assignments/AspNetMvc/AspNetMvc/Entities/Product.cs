using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvc.Entities;

[Table("Products")]
public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public required string Name { get; set; }

    [DataType(DataType.Url)]
    public string? Image { get; set; }

    [Required]
    [Range(minimum: 0, maximum: double.MaxValue)]
    public required decimal Price { get; set; }

    [Column(TypeName = "TEXT")]
    public string? Description { get; set; }

    [Required]
    [ForeignKey("Category")]
    public required int CategoryId { get; set; }
    public Category? Category { get; set; }

    [Required]
    [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "Stock must be greater than or equal 0.")]
    public int Stock { get; set; }

    [Range(minimum: 0, maximum: double.MaxValue)]
    public double SalesPerDay { get; set; }

    [Range(minimum: 0, maximum: double.MaxValue)]
    public double SalesPerMonth { get; set; }

    [Range(minimum: 0, maximum: 5)]
    public float Rating { get; set; }

    [Range(minimum: 0, maximum: int.MaxValue)]
    public int Sales { get; set; }

    [Range(minimum: 0, maximum: double.MaxValue)]
    public decimal Revenue { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime LastUpdate { get; set; } = DateTime.UtcNow;
}
