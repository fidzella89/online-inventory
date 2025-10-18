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
        // Validate category exists
        var category = await _unitOfWork.Categories.GetByIdAsync(dto.CategoryId);
        if (category == null)
        {
            throw new InvalidOperationException($"Category with ID {dto.CategoryId} not found.");
        }

        // Auto-generate SKU based on category
        var sku = await GenerateSkuAsync(category.Name);

        var product = new Product
        {
            SKU = sku,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            QuantityInStock = dto.QuantityInStock,
            CategoryId = dto.CategoryId
        };

        await _unitOfWork.Products.AddAsync(product);
        
        // Save the product first to get the generated ID
        await _unitOfWork.SaveChangesAsync();
        
        // Create initial inventory transaction if stock > 0
        if (dto.QuantityInStock > 0)
        {
            var transaction = new InventoryTransaction
            {
                ProductId = product.Id, // Now product.Id has a valid value
                QuantityChange = dto.QuantityInStock,
                Timestamp = DateTime.UtcNow,
                Reason = "Initial Stock"
            };
            await _unitOfWork.InventoryTransactions.AddAsync(transaction);
            await _unitOfWork.SaveChangesAsync();
        }

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

    private async Task<string> GenerateSkuAsync(string categoryName)
    {
        // Get category prefix (first 4 characters, uppercase)
        var categoryPrefix = categoryName.Length >= 4 
            ? categoryName.Substring(0, 4).ToUpper() 
            : categoryName.ToUpper().PadRight(4, 'X');

        // Get the next number for this category
        var existingSkus = await _unitOfWork.Products.GetSkusByCategoryPrefixAsync(categoryPrefix);
        
        int nextNumber = 1;
        if (existingSkus.Any())
        {
            // Extract numbers from existing SKUs and find the next one
            var numbers = existingSkus
                .Where(sku => sku.StartsWith(categoryPrefix + "-"))
                .Select(sku => 
                {
                    var parts = sku.Split('-');
                    if (parts.Length > 1 && int.TryParse(parts[1], out int num))
                        return num;
                    return 0;
                })
                .Where(num => num > 0)
                .ToList();

            nextNumber = numbers.Any() ? numbers.Max() + 1 : 1;
        }

        return $"{categoryPrefix}-{nextNumber:D3}";
    }
}

