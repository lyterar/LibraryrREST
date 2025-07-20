namespace BookStore.DataAccess.Entities;

public class BookEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public List<OrderItemEntity> OrderItems { get; set; } = new();
    public BookContentEntity BookContent { get; set; }
    public List<CommentEntity> Comments { get; set; } = new();
    public List<AuthorBookEntity> AuthorBooks { get; set; } = new();
}