using Microsoft.EntityFrameworkCore;
using OnlineInventory.Data;
using OnlineInventory.DTOs;
using OnlineInventory.Models;
using OnlineInventory.Repositories;

namespace OnlineInventory.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationDbContext _context;

    public CategoryService(IUnitOfWork unitOfWork, ApplicationDbContext context)
    {
        _unitOfWork = unitOfWork;
        _context = context;
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .Where(c => !c.IsDeleted)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                ProductCount = c.Products.Count(p => !p.IsDeleted)
            })
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories
            .AsNoTracking()
            .Where(c => c.Id == id && !c.IsDeleted)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                ProductCount = c.Products.Count(p => !p.IsDeleted)
            })
            .FirstOrDefaultAsync();
    }

    public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name
        };

        await _unitOfWork.Categories.AddAsync(category);
        await _unitOfWork.SaveChangesAsync();

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            ProductCount = 0
        };
    }

    public async Task<CategoryDto?> UpdateCategoryAsync(int id, UpdateCategoryDto dto)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        if (category == null || category.IsDeleted)
        {
            return null;
        }

        category.Name = dto.Name;
        _unitOfWork.Categories.Update(category);
        await _unitOfWork.SaveChangesAsync();

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            ProductCount = category.Products.Count(p => !p.IsDeleted)
        };
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        if (category == null || category.IsDeleted)
        {
            return false;
        }

        // Check if category has active products
        if (category.Products.Any(p => !p.IsDeleted))
        {
            return false; // Cannot delete category with active products
        }

        category.IsDeleted = true;
        _unitOfWork.Categories.Update(category);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}

