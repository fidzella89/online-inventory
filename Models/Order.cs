using System.ComponentModel.DataAnnotations;

namespace OnlineInventory.Models;

public class Order
{
    public int Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Range(0, double.MaxValue)]
    public decimal Total { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}

