using System.ComponentModel.DataAnnotations;

namespace OnlineInventory.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string SKU { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int QuantityInStock { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

}

