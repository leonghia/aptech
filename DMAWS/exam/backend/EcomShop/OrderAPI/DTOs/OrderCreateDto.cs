using System.ComponentModel.DataAnnotations;

namespace OrderAPI.DTOs;

public class OrderCreateDto
{
    [Required]
    [StringLength(64, MinimumLength = 3)]
    public required string ItemCode { get; set; }

    [Required]
    [StringLength(256, MinimumLength = 3)]
    public required string ItemName { get; set; }

    [Required]
    public required int ItemQty { get; set; }

    [Required]
    public required DateTime OrderDelivery { get; set; }

    [Required]
    public required string OrderAddress { get; set; }

    [Required]
    public required string PhoneNumber { get; set; }
}
