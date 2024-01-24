using System.ComponentModel.DataAnnotations;

namespace OrderAPI.DTOs;

public class OrderEditDto
{
    [Required]
    public required DateTime OrderDelivery { get; set; }

    [Required]
    public required string OrderAddress { get; set; }
}
