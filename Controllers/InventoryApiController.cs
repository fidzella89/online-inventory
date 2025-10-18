using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineInventory.DTOs;
using OnlineInventory.Services;

namespace OnlineInventory.Controllers;

[ApiController]
[Route("api/inventory")]
[Produces("application/json")]
[Authorize(Roles = "Admin,Staff")]
public class InventoryApiController : ControllerBase
{
    private readonly IProductService _productService;

    public InventoryApiController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Get all products with their stock levels
    /// </summary>
    /// <param name="page">Page number (default: 1)</param>
    /// <param name="pageSize">Items per page (default: 10)</param>
    /// <param name="search">Search term for product name or SKU</param>
    /// <param name="categoryId">Filter by category ID</param>
    /// <param name="sortBy">Sort by field (name, price, stock)</param>
    /// <returns>Paginated list of products with stock information</returns>
    [HttpGet("products")]
    public async Task<IActionResult> GetProducts(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? search = null,
        [FromQuery] int? categoryId = null,
        [FromQuery] string? sortBy = null)
    {
        try
        {
            var result = await _productService.GetProductsAsync(page, pageSize, search, categoryId, sortBy);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving products", error = ex.Message });
        }
    }

    /// <summary>
    /// Get a specific product's stock information
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns>Product details with stock information</returns>
    [HttpGet("products/{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        try
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = $"Product with ID {id} not found." });
            }
            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving the product", error = ex.Message });
        }
    }

    /// <summary>
    /// Adjust product stock level
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <param name="request">Stock adjustment request</param>
    /// <returns>Updated product information</returns>
    [HttpPost("products/{id}/adjust")]
    public async Task<IActionResult> AdjustStock(int id, [FromBody] StockAdjustmentRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid request data", errors = ModelState });
            }

            // Get current product
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = $"Product with ID {id} not found." });
            }

            // Calculate new stock level
            var newStock = product.QuantityInStock + request.Adjustment;
            
            // Prevent negative stock
            if (newStock < 0)
            {
                return BadRequest(new { message = "Adjustment would result in negative stock." });
            }

            // Update product stock
            var updateDto = new UpdateProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                QuantityInStock = newStock,
                CategoryId = product.CategoryId
            };

            var updatedProduct = await _productService.UpdateProductAsync(id, updateDto);
            if (updatedProduct == null)
            {
                return StatusCode(500, new { message = "Failed to update product stock." });
            }

            return Ok(new
            {
                message = "Stock adjusted successfully",
                product = updatedProduct,
                adjustment = request.Adjustment,
                previousStock = product.QuantityInStock,
                newStock = newStock,
                reason = request.Reason
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while adjusting stock", error = ex.Message });
        }
    }

    /// <summary>
    /// Get low stock products (stock <= 10)
    /// </summary>
    /// <param name="threshold">Stock threshold (default: 10)</param>
    /// <returns>List of products with low stock</returns>
    [HttpGet("low-stock")]
    public async Task<IActionResult> GetLowStockProducts([FromQuery] int threshold = 10)
    {
        try
        {
            var result = await _productService.GetProductsAsync(1, 1000, null, null, null);
            var lowStockProducts = result.Items.Where(p => p.QuantityInStock <= threshold).ToList();
            
            return Ok(new
            {
                threshold = threshold,
                count = lowStockProducts.Count,
                products = lowStockProducts
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving low stock products", error = ex.Message });
        }
    }
}

/// <summary>
/// Stock adjustment request model
/// </summary>
public class StockAdjustmentRequest
{
    /// <summary>
    /// Stock adjustment amount (positive to increase, negative to decrease)
    /// </summary>
    /// <example>50</example>
    public int Adjustment { get; set; }

    /// <summary>
    /// Reason for the adjustment
    /// </summary>
    /// <example>Restocked from supplier</example>
    public string Reason { get; set; } = string.Empty;
}
