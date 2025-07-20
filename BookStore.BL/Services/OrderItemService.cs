using BookStore.Core.Models;
using BookStore.DataAccess.Repositories;

namespace BookStore.BL.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public Task<List<OrderItem>> GetOrderItemsByOrderId(Guid orderId) =>
        _orderItemRepository.GetByOrderIdAsync(orderId);

    public Task<Guid> CreateOrderItem(OrderItem item) =>
        _orderItemRepository.CreateAsync(item);

    public Task<Guid> UpdateOrderItem(OrderItem item) =>
        _orderItemRepository.UpdateAsync(item);

    public Task<bool> DeleteOrderItem(Guid id) =>
        _orderItemRepository.DeleteAsync(id);
}