using OrderAPI.DTOs;

namespace OrderAPI.Services.OrderService;

public interface IOrderService
{
    Task<OrderGetDto> CreateOrder(OrderCreateDto dto);
    Task EditOrder(int orderId, OrderEditDto dto);
}
