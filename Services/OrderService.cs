using OnlineInventory.DTOs;
using OnlineInventory.Models;
using OnlineInventory.Repositories;

namespace OnlineInventory.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResultDto<OrderDto>> GetOrdersAsync(int page, int pageSize)
    {
        return await _unitOfWork.Orders.GetPagedOrdersAsync(page, pageSize);
    }

    public async Task<OrderDto?> GetOrderByIdAsync(int id)
    {
        return await _unitOfWork.Orders.GetOrderDtoByIdAsync(id);
    }

    public async Task<OrderDto> CreateOrderAsync(CreateOrderDto dto)
    {
        if (dto.Items == null || !dto.Items.Any())
        {
            throw new InvalidOperationException("Order must contain at least one item.");
        }

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var order = new Order
            {
                CreatedAt = DateTime.UtcNow,
                Total = 0
            };

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync(); // Save to get order ID

            decimal totalAmount = 0;

            foreach (var itemDto in dto.Items)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(itemDto.ProductId);
                if (product == null)
                {
                    throw new InvalidOperationException($"Product with ID {itemDto.ProductId} not found.");
                }

                if (product.QuantityInStock < itemDto.Quantity)
                {
                    throw new InvalidOperationException(
                        $"Insufficient stock for product '{product.Name}'. Available: {product.QuantityInStock}, Requested: {itemDto.Quantity}");
                }

                // Create order item
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = itemDto.ProductId,
                    Quantity = itemDto.Quantity,
                    UnitPrice = product.Price
                };

                await _unitOfWork.OrderItems.AddAsync(orderItem);
                totalAmount += orderItem.Quantity * orderItem.UnitPrice;

                // Update inventory
                product.QuantityInStock -= itemDto.Quantity;
                _unitOfWork.Products.Update(product);

                // Create inventory transaction
                var transaction = new InventoryTransaction
                {
                    ProductId = product.Id,
                    QuantityChange = -itemDto.Quantity,
                    Timestamp = DateTime.UtcNow,
                    Reason = $"Sale - Order #{order.Id}"
                };
                await _unitOfWork.InventoryTransactions.AddAsync(transaction);
            }

            order.Total = totalAmount;
            _unitOfWork.Orders.Update(order);

            await _unitOfWork.CommitTransactionAsync();

            return (await _unitOfWork.Orders.GetOrderDtoByIdAsync(order.Id))!;
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}

