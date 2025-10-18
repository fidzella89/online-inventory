using System.ComponentModel.DataAnnotations;

namespace OnlineInventory.ViewModels;

public class InventoryIndexViewModel
{
    public List<ProductStockViewModel> Products { get; set; } = new();
}

public class ProductStockViewModel
{
    public int Id { get; set; }
    public string SKU { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int CurrentStock { get; set; }
    public string Category { get; set; } = string.Empty;
}

public class StockAdjustmentViewModel
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public int CurrentStock { get; set; }
    
    [Required(ErrorMessage = "Adjustment amount is required.")]
    [Range(-9999, 9999, ErrorMessage = "Adjustment must be between -9999 and 9999.")]
    public int Adjustment { get; set; }
    
    [Required(ErrorMessage = "Reason is required.")]
    [StringLength(200, ErrorMessage = "Reason cannot exceed 200 characters.")]
    public string Reason { get; set; } = string.Empty;
}
