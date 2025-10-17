using System.ComponentModel.DataAnnotations;

namespace OnlineInventory.Models;

public class InventoryTransaction
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int QuantityChange { get; set; }

    [Required]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    [Required]
    [StringLength(100)]
    public string Reason { get; set; } = string.Empty; // "Purchase", "Adjustment", "Sale"
}

