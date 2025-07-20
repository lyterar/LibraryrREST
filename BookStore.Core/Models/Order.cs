using System.Text.Json.Serialization;

namespace BookStore.Core.Models;

public class Order
{
    [JsonConstructor]
    public Order(Guid id, Guid userId, DateTime orderDate)
    {
        Id = id;
        UserId = userId;
        OrderDate = orderDate;
    }

    public Guid Id { get; }
    public Guid UserId { get; }
    public DateTime OrderDate { get; }

    public static (Order? Order, string Error) Create(Guid id, Guid userId)
    {
        if (userId == Guid.Empty)
            return (null, "UserId cannot be empty.");

        var order = new Order(id, userId, DateTime.UtcNow);
        return (order, string.Empty);
    }
}