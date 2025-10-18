using System.ComponentModel.DataAnnotations;

namespace OnlineInventory.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    
    [Display(Name = "SKU")]
    public string SKU { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Product Name")]
    public string Name { get; set; } = string.Empty;
    
    [Display(Name = "Description")]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    [Display(Name = "Price")]
    public decimal Price { get; set; }
    
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
    [Display(Name = "Quantity in Stock")]
    public int QuantityInStock { get; set; }
    
    [Required]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }
    
    public string? CategoryName { get; set; }
}

public class ProductListViewModel
{
    public List<ProductViewModel> Products { get; set; } = new();
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public string? SearchTerm { get; set; }
    public int? CategoryFilter { get; set; }
    public string? SortBy { get; set; }
}

