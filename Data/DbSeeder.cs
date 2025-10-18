using OnlineInventory.Models;

namespace OnlineInventory.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Check if database is already seeded
        if (context.Categories.Any())
        {
            return;
        }

        // Seed Categories
        var categories = new List<Category>
        {
            new Category { Name = "Electronics", IsDeleted = false },
            new Category { Name = "Clothing", IsDeleted = false },
            new Category { Name = "Books", IsDeleted = false },
            new Category { Name = "Home & Garden", IsDeleted = false },
            new Category { Name = "Sports & Outdoors", IsDeleted = false },
            new Category { Name = "Toys & Games", IsDeleted = false }
        };
        
        context.Categories.AddRange(categories);
        await context.SaveChangesAsync();

        // Seed Products (Simple - Only 5 products)
        var products = new List<Product>
        {
            // Electronics
            new Product { SKU = "ELEC-001", Name = "Laptop", Description = "High-performance laptop", Price = 999.99m, QuantityInStock = 50, CategoryId = 1, IsDeleted = false },
            new Product { SKU = "ELEC-002", Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m, QuantityInStock = 100, CategoryId = 1, IsDeleted = false },
            
            // Clothing
            new Product { SKU = "CLOT-001", Name = "T-Shirt", Description = "Cotton t-shirt", Price = 19.99m, QuantityInStock = 200, CategoryId = 2, IsDeleted = false },
            
            // Books
            new Product { SKU = "BOOK-001", Name = "Programming Guide", Description = "Complete programming guide", Price = 39.99m, QuantityInStock = 120, CategoryId = 3, IsDeleted = false },
            
            // Home & Garden
            new Product { SKU = "HOME-001", Name = "Coffee Maker", Description = "Automatic coffee maker", Price = 79.99m, QuantityInStock = 45, CategoryId = 4, IsDeleted = false }
        };
        
        context.Products.AddRange(products);
        await context.SaveChangesAsync();
    }
}

