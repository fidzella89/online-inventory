using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineInventory.DTOs;
using OnlineInventory.Services;
using OnlineInventory.ViewModels;

namespace OnlineInventory.Controllers;

[Authorize(Roles = "Admin,Staff")]
[Route("Admin/Products")]
public class AdminProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public AdminProductsController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string? search = null, int? categoryId = null, string? sortBy = null)
    {
        var result = await _productService.GetProductsAsync(page, pageSize, search, categoryId, sortBy);

        var viewModel = new ProductListViewModel
        {
            Products = result.Items.Select(p => new ProductViewModel
            {
                Id = p.Id,
                SKU = p.SKU,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                QuantityInStock = p.QuantityInStock,
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName
            }).ToList(),
            TotalCount = result.TotalCount,
            Page = result.Page,
            PageSize = result.PageSize,
            SearchTerm = search,
            CategoryFilter = categoryId,
            SortBy = sortBy
        };

        ViewBag.Categories = await GetCategorySelectList();
        return View(viewModel);
    }

    [HttpGet("Create")]
    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = await GetCategorySelectList();
        return View(new ProductViewModel());
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var dto = new CreateProductDto
                {
                    SKU = model.SKU,
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    QuantityInStock = model.QuantityInStock,
                    CategoryId = model.CategoryId
                };

                await _productService.CreateProductAsync(dto);
                TempData["SuccessMessage"] = "Product created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
        }

        ViewBag.Categories = await GetCategorySelectList();
        return View(model);
    }

    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        var viewModel = new ProductViewModel
        {
            Id = product.Id,
            SKU = product.SKU,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            QuantityInStock = product.QuantityInStock,
            CategoryId = product.CategoryId,
            CategoryName = product.CategoryName
        };

        ViewBag.Categories = await GetCategorySelectList();
        return View(viewModel);
    }

    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProductViewModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var dto = new UpdateProductDto
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId
                };

                await _productService.UpdateProductAsync(id, dto);
                TempData["SuccessMessage"] = "Product updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
        }

        ViewBag.Categories = await GetCategorySelectList();
        return View(model);
    }

    [HttpPost("Delete/{id}")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")] // Only Admin can delete products
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var success = await _productService.DeleteProductAsync(id);
            if (success)
            {
                TempData["SuccessMessage"] = "Product deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Product not found.";
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error deleting product: {ex.Message}";
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<SelectList> GetCategorySelectList()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return new SelectList(categories, "Id", "Name");
    }
}

