using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineInventory.DTOs;
using OnlineInventory.Services;

namespace OnlineInventory.Controllers;

[ApiController]
[Route("api/inventory")]
[Produces("application/json")]
public class InventoryApiController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryApiController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    /// <summary>
    /// Get inventory transactions with optional product filter
    /// </summary>
    [HttpGet("transactions")]
    public async Task<ActionResult<PagedResultDto<InventoryTransactionDto>>> GetTransactions(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        [FromQuery] int? productId = null)
    {
        if (page < 1) page = 1;
        if (pageSize < 1 || pageSize > 100) pageSize = 20;

        var result = await _inventoryService.GetTransactionsAsync(page, pageSize, productId);
        return Ok(result);
    }

    /// <summary>
    /// Adjust product inventory (manual adjustment)
    /// </summary>
    [HttpPost("adjust")]
    public async Task<ActionResult<InventoryTransactionDto>> AdjustInventory([FromBody] CreateInventoryAdjustmentDto dto)
    {
        try
        {
            var transaction = await _inventoryService.AdjustInventoryAsync(dto);
            return Ok(transaction);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

