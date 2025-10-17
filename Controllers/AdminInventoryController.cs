using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineInventory.DTOs;
using OnlineInventory.Services;
using OnlineInventory.ViewModels;

namespace OnlineInventory.Controllers;

[Authorize(Roles = "Admin,Staff")]
[Route("Admin/Inventory")]
public class AdminInventoryController : Controller
{
    private readonly IInventoryService _inventoryService;
    private readonly IProductService _productService;

    public AdminInventoryController(IInventoryService inventoryService, IProductService productService)
    {
        _inventoryService = inventoryService;
        _productService = productService;
    }

    [HttpGet("Transactions")]
    public async Task<IActionResult> Transactions(int page = 1, int pageSize = 20, int? productId = null)
    {
        var result = await _inventoryService.GetTransactionsAsync(page, pageSize, productId);

        var viewModel = new InventoryTransactionListViewModel
        {
            Transactions = result.Items.Select(t => new InventoryTransactionItemViewModel
            {
                Id = t.Id,
                ProductId = t.ProductId,
                ProductName = t.ProductName,
                ProductSKU = t.ProductSKU,
                QuantityChange = t.QuantityChange,
                Timestamp = t.Timestamp,
                Reason = t.Reason
            }).ToList(),
            Page = result.Page,
            PageSize = result.PageSize,
            TotalCount = result.TotalCount
        };

        return View(viewModel);
    }

    [HttpGet("Adjust")]
    public async Task<IActionResult> Adjust(int? productId = null)
    {
        var model = new InventoryAdjustmentViewModel();

        if (productId.HasValue)
        {
            var product = await _productService.GetProductByIdAsync(productId.Value);
            if (product != null)
            {
                model.ProductId = product.Id;
                model.ProductName = product.Name;
                model.CurrentStock = product.QuantityInStock;
            }
        }

        ViewBag.Products = await GetProductSelectList();
        return View(model);
    }

    [HttpPost("Adjust")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Adjust(InventoryAdjustmentViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var dto = new CreateInventoryAdjustmentDto
                {
                    ProductId = model.ProductId,
                    QuantityChange = model.QuantityChange,
                    Reason = model.Reason
                };

                await _inventoryService.AdjustInventoryAsync(dto);
                TempData["SuccessMessage"] = "Inventory adjusted successfully.";
                return RedirectToAction(nameof(Transactions));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
        }

        ViewBag.Products = await GetProductSelectList();
        return View(model);
    }

    private async Task<SelectList> GetProductSelectList()
    {
        var products = await _productService.GetProductsAsync(1, 1000, null, null, "name_asc");
        return new SelectList(
            products.Items.Select(p => new { Id = p.Id, Display = $"{p.Name} (SKU: {p.SKU})" }),
            "Id",
            "Display"
        );
    }
}

