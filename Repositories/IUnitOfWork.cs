using OnlineInventory.Models;

namespace OnlineInventory.Repositories;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    IRepository<Category> Categories { get; }
    IRepository<InventoryTransaction> InventoryTransactions { get; }
    IRepository<OrderItem> OrderItems { get; }
    
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}

