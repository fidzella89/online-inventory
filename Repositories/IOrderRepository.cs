using OnlineInventory.DTOs;
using OnlineInventory.Models;

namespace OnlineInventory.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<PagedResultDto<OrderDto>> GetPagedOrdersAsync(int page, int pageSize);
    Task<OrderDto?> GetOrderDtoByIdAsync(int id);
}

