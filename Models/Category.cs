using System.ComponentModel.DataAnnotations;

namespace OnlineInventory.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public bool IsDeleted { get; set; } = false;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}

