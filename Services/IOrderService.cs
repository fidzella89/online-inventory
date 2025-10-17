using OnlineInventory.DTOs;

namespace OnlineInventory.Services;

public interface IOrderService
{
    Task<PagedResultDto<OrderDto>> GetOrdersAsync(int page, int pageSize);
    Task<OrderDto?> GetOrderByIdAsync(int id);
    Task<OrderDto> CreateOrderAsync(CreateOrderDto dto);
}

