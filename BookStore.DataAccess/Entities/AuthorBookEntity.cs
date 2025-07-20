namespace BookStore.DataAccess.Entities;

public class AuthorBookEntity
{
    public Guid AuthorId { get; set; }
    public AuthorEntity Author { get; set; }

    public Guid BookId { get; set; }
    public BookEntity Book { get; set; }
}