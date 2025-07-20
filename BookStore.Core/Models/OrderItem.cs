using System.Text.Json.Serialization;

namespace BookStore.Core.Models;

public class OrderItem
{
    [JsonConstructor]
    public OrderItem(Guid id, Guid orderId, Guid bookId, decimal priceAtPurchase)
    {
        Id = id;
        OrderId = orderId;
        BookId = bookId;
        PriceAtPurchase = priceAtPurchase;
    }

    public Guid Id { get; }
    public Guid OrderId { get; }
    public Guid BookId { get; }
    public decimal PriceAtPurchase { get; }

    public static (OrderItem? Item, string Error) Create(Guid id, Guid orderId, Guid bookId, decimal priceAtPurchase)
    {
        if (orderId == Guid.Empty || bookId == Guid.Empty)
            return (null, "OrderId and BookId cannot be empty.");

        if (priceAtPurchase < 0)
            return (null, "Price must be non-negative.");

        var item = new OrderItem(id, orderId, bookId, priceAtPurchase);
        return (item, string.Empty);
    }
}