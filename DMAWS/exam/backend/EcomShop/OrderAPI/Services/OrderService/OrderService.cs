using Microsoft.EntityFrameworkCore;
using OrderAPI.DatabaseContexts;
using OrderAPI.DTOs;
using OrderAPI.Entities;

namespace OrderAPI.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly OrderContext _context;

    public OrderService(OrderContext context)
    {
        _context = context;
    }

    public async Task<OrderGetDto> CreateOrder(OrderCreateDto dto)
    {
        var orderToCreate = new Order
        {
            ItemCode = dto.ItemCode,
            ItemName = dto.ItemName,
            ItemQty = dto.ItemQty,
            OrderDelivery = dto.OrderDelivery,
            OrderAddress = dto.OrderAddress,
            PhoneNumber = dto.PhoneNumber
        };

        _context.Orders.Add(orderToCreate);
        await _context.SaveChangesAsync();

        var orderToReturn = new OrderGetDto
        {
            Id = orderToCreate.Id,
            ItemCode = orderToCreate.ItemCode,
            ItemName = orderToCreate.ItemName,
            ItemQty = orderToCreate.ItemQty,
            OrderDelivery = orderToCreate.OrderDelivery,
            OrderAddress = orderToCreate.OrderAddress,
            PhoneNumber = orderToCreate.PhoneNumber
        };

        return orderToReturn;
    }

    public async Task EditOrder(int orderId, OrderEditDto dto)
    {
        var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId) ?? throw new ArgumentException(null, nameof(orderId));

        orderToUpdate.OrderDelivery = dto.OrderDelivery;
        orderToUpdate.OrderAddress = dto.OrderAddress;

        _context.Orders.Update(orderToUpdate);

        await _context.SaveChangesAsync();
    }
}
