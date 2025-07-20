using BookStore.Core.Models;

namespace BookStore.BL.Services;

public interface IOrderItemService
{
    Task<List<OrderItem>> GetOrderItemsByOrderId(Guid orderId);
    Task<Guid> CreateOrderItem(OrderItem item);
    Task<Guid> UpdateOrderItem(OrderItem item);
    Task<bool> DeleteOrderItem(Guid id);
}