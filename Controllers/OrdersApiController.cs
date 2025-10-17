using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineInventory.DTOs;
using OnlineInventory.Services;

namespace OnlineInventory.Controllers;

[ApiController]
[Route("api/orders")]
[Produces("application/json")]
public class OrdersApiController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersApiController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Get paginated list of orders
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<PagedResultDto<OrderDto>>> GetOrders(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20)
    {
        if (page < 1) page = 1;
        if (pageSize < 1 || pageSize > 100) pageSize = 20;

        var result = await _orderService.GetOrdersAsync(page, pageSize);
        return Ok(result);
    }

    /// <summary>
    /// Get order by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetOrder(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound(new { message = $"Order with ID {id} not found." });
        }

        return Ok(order);
    }

    /// <summary>
    /// Create new order (reduces inventory automatically)
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] CreateOrderDto dto)
    {
        try
        {
            var order = await _orderService.CreateOrderAsync(dto);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

