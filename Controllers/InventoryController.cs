using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineInventory.Models;
using OnlineInventory.Repositories;
using OnlineInventory.Services;
using OnlineInventory.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace OnlineInventory.Controllers;

[Authorize(Roles = "Admin,Staff")]
[ApiExplorerSettings(IgnoreApi = true)]
public class InventoryController : Controller
{
    private readonly IProductService _productService;
    private readonly IUnitOfWork _unitOfWork;

    public InventoryController(IProductService productService, IUnitOfWork unitOfWork)
    {
        _productService = productService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        // Get all products with pagination (large page size to get all)
        var result = await _productService.GetProductsAsync(1, 1000, null, null, null);
        
        var viewModel = new InventoryIndexViewModel
        {
            Products = result.Items.Select(p => new ProductStockViewModel
            {
                Id = p.Id,
                SKU = p.SKU,
                Name = p.Name,
                CurrentStock = p.QuantityInStock,
                Category = p.CategoryName
            }).ToList()
        };

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Adjust(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        var viewModel = new StockAdjustmentViewModel
        {
            ProductId = product.Id,
            ProductName = product.Name,
            SKU = product.SKU,
            CurrentStock = product.QuantityInStock,
            Adjustment = 0,
            Reason = string.Empty
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Adjust(StockAdjustmentViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var product = await _unitOfWork.Products.GetByIdAsync(model.ProductId);
        if (product == null)
        {
            return NotFound();
        }

        // Calculate new stock level
        var newStock = product.QuantityInStock + model.Adjustment;
        
        // Prevent negative stock
        if (newStock < 0)
        {
            ModelState.AddModelError(nameof(model.Adjustment), "Adjustment would result in negative stock.");
            model.ProductName = product.Name;
            model.SKU = product.SKU;
            model.CurrentStock = product.QuantityInStock;
            return View(model);
        }

        // Update stock
        product.QuantityInStock = newStock;
        await _unitOfWork.SaveChangesAsync();

        TempData["SuccessMessage"] = $"Stock adjusted successfully. New stock level: {newStock}";
        return RedirectToAction(nameof(Index));
    }
}
