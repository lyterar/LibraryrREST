using BookStore.Core.Models;

namespace BookStore.DataAccess.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id);
    Task<List<Order>> GetByUserIdAsync(Guid userId);
    Task<Guid> CreateAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(Guid id);
}