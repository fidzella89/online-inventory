using OnlineInventory.DTOs;

namespace OnlineInventory.Services;

public interface IInventoryService
{
    Task<InventoryTransactionDto> AdjustInventoryAsync(CreateInventoryAdjustmentDto dto);
    Task<PagedResultDto<InventoryTransactionDto>> GetTransactionsAsync(int page, int pageSize, int? productId = null);
}

