namespace BookStore.DataAccess.Entities;

public class OrderEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }

    public DateTime OrderDate { get; set; }

    public List<OrderItemEntity> Items { get; set; } = new();
}