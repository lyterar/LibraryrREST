using BookStore.Core.Models;

namespace BookStore.DataAccess.Repositories;

public interface IOrderItemRepository
{
    Task<List<OrderItem>> GetByOrderIdAsync(Guid orderId);
    Task<Guid> CreateAsync(OrderItem item);
    Task<Guid> UpdateAsync(OrderItem item);
    Task<bool> DeleteAsync(Guid id);
}