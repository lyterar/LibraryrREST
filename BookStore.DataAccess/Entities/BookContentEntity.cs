namespace BookStore.DataAccess.Entities;

public class BookContentEntity
{
    public Guid BookId { get; set; }
    public BookEntity Book { get; set; }

    public string Content { get; set; } = string.Empty;
}