using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineInventory.Models;

namespace OnlineInventory.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<InventoryTransaction> InventoryTransactions => Set<InventoryTransaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Customize Identity table names
        modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

        // Customize ApplicationUser properties
        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            // Remove unnecessary columns
            entity.Ignore(e => e.ConcurrencyStamp);
            entity.Ignore(e => e.EmailConfirmed);
            entity.Ignore(e => e.LockoutEnd);
            entity.Ignore(e => e.PhoneNumber);
            entity.Ignore(e => e.PhoneNumberConfirmed);
            entity.Ignore(e => e.TwoFactorEnabled);
            
            // Rename columns for cleaner names
            entity.Property(e => e.LockoutEnabled).HasColumnName("IsActive");
            entity.Property(e => e.PasswordHash).HasColumnName("Password");
        });

        // Simplify other Identity tables
        modelBuilder.Entity<IdentityRole>(entity =>
        {
            // Remove unnecessary columns from Roles
            entity.Ignore(e => e.ConcurrencyStamp);
        });

        modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
        {
            // Keep only essential fields for UserClaims
            entity.Property(e => e.ClaimType).HasMaxLength(256);
            entity.Property(e => e.ClaimValue).HasMaxLength(256);
        });

        modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            // Keep only essential fields for RoleClaims
            entity.Property(e => e.ClaimType).HasMaxLength(256);
            entity.Property(e => e.ClaimValue).HasMaxLength(256);
        });

        // Remove UserLogins and UserTokens tables entirely (not needed for simple auth)
        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Ignore<IdentityUserToken<string>>();

        // Product configuration
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.SKU).IsUnique();
            entity.HasIndex(e => e.CategoryId);
            entity.HasIndex(e => e.Name);
            
            entity.Property(e => e.Price).HasPrecision(18, 2);
            
            entity.HasOne(e => e.Category)
                  .WithMany(c => c.Products)
                  .HasForeignKey(e => e.CategoryId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Category configuration
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Name).IsUnique();
        });

        // Order configuration
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.CreatedAt);
            
            entity.Property(e => e.Total).HasPrecision(18, 2);
        });

        // OrderItem configuration
        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.OrderId);
            entity.HasIndex(e => e.ProductId);
            
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
            
            entity.HasOne(e => e.Order)
                  .WithMany(o => o.Items)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);
                  
            entity.HasOne(e => e.Product)
                  .WithMany()
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // InventoryTransaction configuration
        modelBuilder.Entity<InventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.ProductId);
            entity.HasIndex(e => e.Timestamp);
            
            entity.HasOne(e => e.Product)
                  .WithMany(p => p.InventoryTransactions)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}

