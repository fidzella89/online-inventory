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
            new Category { Name = "Electronics" },
            new Category { Name = "Clothing" },
            new Category { Name = "Books" },
            new Category { Name = "Home & Garden" },
            new Category { Name = "Sports & Outdoors" },
            new Category { Name = "Toys & Games" }
        };
        
        context.Categories.AddRange(categories);
        await context.SaveChangesAsync();

        // Seed Products (Simple - Only 5 products)
        var products = new List<Product>
        {
            // Electronics
            new Product { SKU = "ELEC-001", Name = "Laptop", Description = "High-performance laptop", Price = 999.99m, QuantityInStock = 50, CategoryId = 1 },
            new Product { SKU = "ELEC-002", Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m, QuantityInStock = 100, CategoryId = 1 },
            
            // Clothing
            new Product { SKU = "CLOT-001", Name = "T-Shirt", Description = "Cotton t-shirt", Price = 19.99m, QuantityInStock = 200, CategoryId = 2 },
            
            // Books
            new Product { SKU = "BOOK-001", Name = "Programming Guide", Description = "Complete programming guide", Price = 39.99m, QuantityInStock = 120, CategoryId = 3 },
            
            // Home & Garden
            new Product { SKU = "HOME-001", Name = "Coffee Maker", Description = "Automatic coffee maker", Price = 79.99m, QuantityInStock = 45, CategoryId = 4 }
        };
        
        context.Products.AddRange(products);
        await context.SaveChangesAsync();

        // Seed Initial Inventory Transactions
        var transactions = new List<InventoryTransaction>();
        foreach (var product in products)
        {
            transactions.Add(new InventoryTransaction
            {
                ProductId = product.Id,
                QuantityChange = product.QuantityInStock,
                Timestamp = DateTime.UtcNow.AddDays(-30),
                Reason = "Initial Stock"
            });
        }
        
        context.InventoryTransactions.AddRange(transactions);
        await context.SaveChangesAsync();
    }
}

