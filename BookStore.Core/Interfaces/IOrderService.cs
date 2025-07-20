using BookStore.Core.Models;

namespace BookStore.BL.Services;

public interface IOrderService
{
    Task<List<Order>> GetOrdersByUserId(Guid userId);
    Task<Order?> GetOrderById(Guid id);
    Task<Guid> CreateOrder(Order order);
    Task UpdateOrder(Order order);
    Task DeleteOrder(Guid id);
}