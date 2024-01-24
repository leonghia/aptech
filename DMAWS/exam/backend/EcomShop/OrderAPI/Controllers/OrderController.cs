using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderAPI.DatabaseContexts;
using OrderAPI.DTOs;
using OrderAPI.Services.OrderService;

namespace OrderAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly OrderContext _context;

    public OrderController(IOrderService orderService, OrderContext context)
    {
        _orderService = orderService;
        _context = context;
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> Create([FromBody] OrderCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var orderCreated = await _orderService.CreateOrder(dto);

        return Created("", orderCreated);
    }

    [HttpPut("{id:int}")]
    [Consumes("application/json")]
    public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] OrderEditDto dto)
    {
        var isExist = await _context.Orders.AnyAsync(o => o.Id == id);
        if (!isExist)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        await _orderService.EditOrder(id, dto);

        return NoContent();
    }
}
