using Microsoft.EntityFrameworkCore;
using OnlineInventory.Data;
using OnlineInventory.DTOs;
using OnlineInventory.Models;
using OnlineInventory.Repositories;

namespace OnlineInventory.Services;

public class InventoryService : IInventoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationDbContext _context;

    public InventoryService(IUnitOfWork unitOfWork, ApplicationDbContext context)
    {
        _unitOfWork = unitOfWork;
        _context = context;
    }

    public async Task<InventoryTransactionDto> AdjustInventoryAsync(CreateInventoryAdjustmentDto dto)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(dto.ProductId);
        if (product == null)
        {
            throw new InvalidOperationException($"Product with ID {dto.ProductId} not found.");
        }

        var newQuantity = product.QuantityInStock + dto.QuantityChange;
        if (newQuantity < 0)
        {
            throw new InvalidOperationException(
                $"Adjustment would result in negative stock. Current: {product.QuantityInStock}, Change: {dto.QuantityChange}");
        }

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            product.QuantityInStock = newQuantity;
            _unitOfWork.Products.Update(product);

            var transaction = new InventoryTransaction
            {
                ProductId = dto.ProductId,
                QuantityChange = dto.QuantityChange,
                Timestamp = DateTime.UtcNow,
                Reason = dto.Reason
            };

            await _unitOfWork.InventoryTransactions.AddAsync(transaction);
            await _unitOfWork.CommitTransactionAsync();

            return new InventoryTransactionDto
            {
                Id = transaction.Id,
                ProductId = transaction.ProductId,
                ProductName = product.Name,
                ProductSKU = product.SKU,
                QuantityChange = transaction.QuantityChange,
                Timestamp = transaction.Timestamp,
                Reason = transaction.Reason
            };
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<PagedResultDto<InventoryTransactionDto>> GetTransactionsAsync(
        int page, 
        int pageSize, 
        int? productId = null)
    {
        var query = _context.InventoryTransactions.AsNoTracking();

        if (productId.HasValue)
        {
            query = query.Where(t => t.ProductId == productId.Value);
        }

        var totalCount = await query.CountAsync();

        var items = await query
            .OrderByDescending(t => t.Timestamp)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(t => new InventoryTransactionDto
            {
                Id = t.Id,
                ProductId = t.ProductId,
                ProductName = t.Product.Name,
                ProductSKU = t.Product.SKU,
                QuantityChange = t.QuantityChange,
                Timestamp = t.Timestamp,
                Reason = t.Reason
            })
            .ToListAsync();

        return new PagedResultDto<InventoryTransactionDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }
}

