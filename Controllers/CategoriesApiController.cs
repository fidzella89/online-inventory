using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineInventory.DTOs;
using OnlineInventory.Services;

namespace OnlineInventory.Controllers;

[ApiController]
[Route("api/categories")]
[Produces("application/json")]
[Authorize(Roles = "Admin")]
public class CategoriesApiController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesApiController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    private IActionResult? CheckAdminAccess()
    {
        if (!User.IsInRole("Admin"))
        {
            return Forbid("Only administrators can access this resource.");
        }
        return null;
    }

    /// <summary>
    /// Get all categories
    /// </summary>
    /// <returns>List of all categories</returns>
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var adminCheck = CheckAdminAccess();
        if (adminCheck != null) return adminCheck;

        try
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving categories", error = ex.Message });
        }
    }

    /// <summary>
    /// Get category by ID
    /// </summary>
    /// <param name="id">Category ID</param>
    /// <returns>Category details</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var adminCheck = CheckAdminAccess();
        if (adminCheck != null) return adminCheck;

        try
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound(new { message = $"Category with ID {id} not found." });
            }
            return Ok(category);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving the category", error = ex.Message });
        }
    }

    /// <summary>
    /// Create a new category
    /// </summary>
    /// <param name="dto">Category creation data</param>
    /// <returns>Created category details</returns>
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
    {
        var adminCheck = CheckAdminAccess();
        if (adminCheck != null) return adminCheck;

        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid request data", errors = ModelState });
            }

            var category = await _categoryService.CreateCategoryAsync(dto);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Update an existing category
    /// </summary>
    /// <param name="id">Category ID</param>
    /// <param name="dto">Category update data</param>
    /// <returns>Updated category details</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto dto)
    {
        var adminCheck = CheckAdminAccess();
        if (adminCheck != null) return adminCheck;

        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid request data", errors = ModelState });
            }

            var category = await _categoryService.UpdateCategoryAsync(id, dto);
            if (category == null)
            {
                return NotFound(new { message = $"Category with ID {id} not found." });
            }
            return Ok(category);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Delete a category (Admin only)
    /// </summary>
    /// <param name="id">Category ID</param>
    /// <returns>Deletion confirmation</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var adminCheck = CheckAdminAccess();
        if (adminCheck != null) return adminCheck;

        try
        {
            var success = await _categoryService.DeleteCategoryAsync(id);
            if (!success)
            {
                return NotFound(new { message = $"Category with ID {id} not found or cannot be deleted (may have associated products)." });
            }
            return Ok(new { message = "Category deleted successfully." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
