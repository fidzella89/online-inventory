using System.ComponentModel.DataAnnotations;

namespace OnlineInventory.ViewModels;

public class InventoryAdjustmentViewModel
{
    [Required]
    [Display(Name = "Product")]
    public int ProductId { get; set; }
    
    [Required]
    [Display(Name = "Quantity Change")]
    [Range(-10000, 10000, ErrorMessage = "Quantity change must be between -10000 and 10000")]
    public int QuantityChange { get; set; }
    
    [Required]
    [Display(Name = "Reason")]
    public string Reason { get; set; } = string.Empty;
    
    public string? ProductName { get; set; }
    public int? CurrentStock { get; set; }
}

public class InventoryTransactionListViewModel
{
    public List<InventoryTransactionItemViewModel> Transactions { get; set; } = new();
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}

public class InventoryTransactionItemViewModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductSKU { get; set; } = string.Empty;
    public int QuantityChange { get; set; }
    public DateTime Timestamp { get; set; }
    public string Reason { get; set; } = string.Empty;
}

