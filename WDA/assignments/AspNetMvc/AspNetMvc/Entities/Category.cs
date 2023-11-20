using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvc.Entities;

[Table("Categories")]
public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 5)]
    public required string Name { get; set; }

    public ICollection<Product>? Products { get; set; }
}
