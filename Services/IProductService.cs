using OnlineInventory.DTOs;

namespace OnlineInventory.Services;

public interface IProductService
{
    Task<PagedResultDto<ProductDto>> GetProductsAsync(int page, int pageSize, string? search, int? categoryId, string? sortBy);
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<ProductDto> CreateProductAsync(CreateProductDto dto);
    Task<ProductDto?> UpdateProductAsync(int id, UpdateProductDto dto);
    Task<bool> DeleteProductAsync(int id);
}

