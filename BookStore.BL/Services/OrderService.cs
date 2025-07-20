using BookStore.Core.Models;
using BookStore.DataAccess.Repositories;

namespace BookStore.BL.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<List<Order>> GetOrdersByUserId(Guid userId) =>
        _orderRepository.GetByUserIdAsync(userId);

    public Task<Order?> GetOrderById(Guid id) =>
        _orderRepository.GetByIdAsync(id);

    public Task<Guid> CreateOrder(Order order) =>
        _orderRepository.CreateAsync(order);

    public Task UpdateOrder(Order order) =>
        _orderRepository.UpdateAsync(order);

    public Task DeleteOrder(Guid id) =>
        _orderRepository.DeleteAsync(id);
}