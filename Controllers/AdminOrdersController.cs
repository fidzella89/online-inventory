using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineInventory.Services;
using OnlineInventory.ViewModels;

namespace OnlineInventory.Controllers;

[Authorize(Roles = "Admin,Staff")] // Both can view orders
[Route("Admin/Orders")]
public class AdminOrdersController : Controller
{
    private readonly IOrderService _orderService;

    public AdminOrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 20)
    {
        var result = await _orderService.GetOrdersAsync(page, pageSize);

        var viewModel = new OrderListViewModel
        {
            Orders = result.Items.Select(o => new OrderSummaryViewModel
            {
                Id = o.Id,
                CreatedAt = o.CreatedAt,
                Total = o.Total,
                ItemCount = o.Items.Count
            }).ToList(),
            Page = result.Page,
            PageSize = result.PageSize,
            TotalCount = result.TotalCount
        };

        return View(viewModel);
    }

    [HttpGet("Details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        var viewModel = new OrderDetailsViewModel
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            Total = order.Total,
            Items = order.Items.Select(i => new OrderItemViewModel
            {
                ProductName = i.ProductName,
                ProductSKU = i.ProductSKU,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };

        return View(viewModel);
    }
}

