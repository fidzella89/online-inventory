using OnlineInventory.DTOs;
using OnlineInventory.Models;
using OnlineInventory.Repositories;

namespace OnlineInventory.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResultDto<ProductDto>> GetProductsAsync(
        int page, 
        int pageSize, 
        string? search, 
        int? categoryId, 
        string? sortBy)
    {
        return await _unitOfWork.Products.GetPagedProductsAsync(page, pageSize, search, categoryId, sortBy);
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        return await _unitOfWork.Products.GetProductDtoByIdAsync(id);
    }

    public async Task<ProductDto> CreateProductAsync(CreateProductDto dto)
    {
        // Validate SKU uniqueness
        if (await _unitOfWork.Products.SkuExistsAsync(dto.SKU))
        {
            throw new InvalidOperationException($"Product with SKU '{dto.SKU}' already exists.");
        }

        // Validate category exists
        var category = await _unitOfWork.Categories.GetByIdAsync(dto.CategoryId);
        if (category == null)
        {
            throw new InvalidOperationException($"Category with ID {dto.CategoryId} not found.");
        }

        var product = new Product
        {
            SKU = dto.SKU,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            QuantityInStock = dto.QuantityInStock,
            CategoryId = dto.CategoryId
        };

        await _unitOfWork.Products.AddAsync(product);
        
        // Create initial inventory transaction if stock > 0
        if (dto.QuantityInStock > 0)
        {
            var transaction = new InventoryTransaction
            {
                ProductId = product.Id,
                QuantityChange = dto.QuantityInStock,
                Timestamp = DateTime.UtcNow,
                Reason = "Initial Stock"
            };
            await _unitOfWork.InventoryTransactions.AddAsync(transaction);
        }
        
        await _unitOfWork.SaveChangesAsync();

        return (await _unitOfWork.Products.GetProductDtoByIdAsync(product.Id))!;
    }

    public async Task<ProductDto?> UpdateProductAsync(int id, UpdateProductDto dto)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product == null)
        {
            return null;
        }

        // Validate category exists
        var category = await _unitOfWork.Categories.GetByIdAsync(dto.CategoryId);
        if (category == null)
        {
            throw new InvalidOperationException($"Category with ID {dto.CategoryId} not found.");
        }

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.CategoryId = dto.CategoryId;

        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveChangesAsync();

        return await _unitOfWork.Products.GetProductDtoByIdAsync(id);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product == null)
        {
            return false;
        }

        _unitOfWork.Products.Remove(product);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}

