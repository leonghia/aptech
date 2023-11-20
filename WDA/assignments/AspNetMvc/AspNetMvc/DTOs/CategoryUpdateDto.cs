using System.ComponentModel.DataAnnotations;

namespace AspNetMvc.DTOs
{
    public class CategoryUpdateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public required string Name { get; set; }
    }
}