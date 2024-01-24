namespace OrderAPI.DTOs;

public class OrderGetDto
{
    public required int Id { get; set; }  
    public required string ItemCode { get; set; }   
    public required string ItemName { get; set; }
    public required int ItemQty { get; set; }
    public required DateTime OrderDelivery { get; set; }
    public required string OrderAddress { get; set; }
    public required string PhoneNumber { get; set; }
}
