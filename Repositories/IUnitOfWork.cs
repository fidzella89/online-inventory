using OnlineInventory.Models;

namespace OnlineInventory.Repositories;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IRepository<Category> Categories { get; }
    
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}

