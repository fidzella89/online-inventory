using OnlineInventory.DTOs;
using OnlineInventory.Models;

namespace OnlineInventory.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<PagedResultDto<ProductDto>> GetPagedProductsAsync(
        int page, 
        int pageSize, 
        string? search = null, 
        int? categoryId = null, 
        string? sortBy = null);
    
    Task<ProductDto?> GetProductDtoByIdAsync(int id);
    Task<Product?> GetBySkuAsync(string sku);
    Task<bool> SkuExistsAsync(string sku, int? excludeId = null);
}

