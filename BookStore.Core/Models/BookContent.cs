using System.Text.Json.Serialization;

namespace BookStore.Core.Models;

public class BookContent
{
    [JsonConstructor]
    public BookContent(Guid bookId, string content)
    {
        BookId = bookId;
        Content = content;
    }

    public Guid BookId { get; }
    public string Content { get; } = string.Empty;

    public static (BookContent? Content, string Error) Create(Guid bookId, string content)
    {
        if (bookId == Guid.Empty)
            return (null, "BookId cannot be empty.");

        if (string.IsNullOrWhiteSpace(content))
            return (null, "Book content cannot be empty.");

        var result = new BookContent(bookId, content);
        return (result, string.Empty);
    }
}