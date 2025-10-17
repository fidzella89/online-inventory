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

        // Seed Products
        var products = new List<Product>
        {
            // Electronics
            new Product { SKU = "ELEC-001", Name = "Laptop", Description = "High-performance laptop", Price = 999.99m, QuantityInStock = 50, CategoryId = 1 },
            new Product { SKU = "ELEC-002", Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m, QuantityInStock = 100, CategoryId = 1 },
            new Product { SKU = "ELEC-003", Name = "Wireless Headphones", Description = "Noise-cancelling headphones", Price = 199.99m, QuantityInStock = 75, CategoryId = 1 },
            new Product { SKU = "ELEC-004", Name = "Tablet", Description = "10-inch tablet", Price = 399.99m, QuantityInStock = 60, CategoryId = 1 },
            new Product { SKU = "ELEC-005", Name = "Smart Watch", Description = "Fitness tracking smartwatch", Price = 249.99m, QuantityInStock = 80, CategoryId = 1 },
            
            // Clothing
            new Product { SKU = "CLOT-001", Name = "T-Shirt", Description = "Cotton t-shirt", Price = 19.99m, QuantityInStock = 200, CategoryId = 2 },
            new Product { SKU = "CLOT-002", Name = "Jeans", Description = "Denim jeans", Price = 49.99m, QuantityInStock = 150, CategoryId = 2 },
            new Product { SKU = "CLOT-003", Name = "Jacket", Description = "Winter jacket", Price = 89.99m, QuantityInStock = 75, CategoryId = 2 },
            new Product { SKU = "CLOT-004", Name = "Sneakers", Description = "Running sneakers", Price = 79.99m, QuantityInStock = 100, CategoryId = 2 },
            
            // Books
            new Product { SKU = "BOOK-001", Name = "Programming Guide", Description = "Complete programming guide", Price = 39.99m, QuantityInStock = 120, CategoryId = 3 },
            new Product { SKU = "BOOK-002", Name = "Science Fiction Novel", Description = "Bestselling sci-fi novel", Price = 14.99m, QuantityInStock = 200, CategoryId = 3 },
            new Product { SKU = "BOOK-003", Name = "Cookbook", Description = "International recipes", Price = 24.99m, QuantityInStock = 90, CategoryId = 3 },
            
            // Home & Garden
            new Product { SKU = "HOME-001", Name = "Coffee Maker", Description = "Automatic coffee maker", Price = 79.99m, QuantityInStock = 45, CategoryId = 4 },
            new Product { SKU = "HOME-002", Name = "Blender", Description = "High-speed blender", Price = 59.99m, QuantityInStock = 60, CategoryId = 4 },
            new Product { SKU = "HOME-003", Name = "Garden Tools Set", Description = "Complete garden tools", Price = 49.99m, QuantityInStock = 40, CategoryId = 4 },
            
            // Sports & Outdoors
            new Product { SKU = "SPORT-001", Name = "Yoga Mat", Description = "Non-slip yoga mat", Price = 29.99m, QuantityInStock = 150, CategoryId = 5 },
            new Product { SKU = "SPORT-002", Name = "Dumbbell Set", Description = "Adjustable dumbbells", Price = 149.99m, QuantityInStock = 55, CategoryId = 5 },
            new Product { SKU = "SPORT-003", Name = "Camping Tent", Description = "4-person camping tent", Price = 199.99m, QuantityInStock = 30, CategoryId = 5 },
            
            // Toys & Games
            new Product { SKU = "TOY-001", Name = "Board Game", Description = "Family board game", Price = 34.99m, QuantityInStock = 100, CategoryId = 6 },
            new Product { SKU = "TOY-002", Name = "Puzzle Set", Description = "1000-piece puzzle", Price = 19.99m, QuantityInStock = 120, CategoryId = 6 },
            new Product { SKU = "TOY-003", Name = "Action Figure", Description = "Collectible action figure", Price = 24.99m, QuantityInStock = 200, CategoryId = 6 }
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

