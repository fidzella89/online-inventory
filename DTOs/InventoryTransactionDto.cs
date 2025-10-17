namespace OnlineInventory.DTOs;

public class InventoryTransactionDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductSKU { get; set; } = string.Empty;
    public int QuantityChange { get; set; }
    public DateTime Timestamp { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public class CreateInventoryAdjustmentDto
{
    public int ProductId { get; set; }
    public int QuantityChange { get; set; }
    public string Reason { get; set; } = string.Empty;
}

