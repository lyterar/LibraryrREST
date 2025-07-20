using System.Text.Json.Serialization;

namespace BookStore.Core.Models;

public class Book
{
    public const int MAX_TITLE_LENGTH = 100;

    [JsonConstructor]
    public Book(Guid id, string title, string description, decimal price)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
    }

    public Guid Id { get; }
    public string Title { get; } = string.Empty;
    public string Description { get; } = string.Empty;
    public decimal Price { get; }

    public static (Book? Book, string Error) Create(Guid id, string title, string description, decimal price)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > MAX_TITLE_LENGTH)
        {
            return (null, "Title cannot be empty or longer than 100 characters");
        }

        var book = new Book(id, title, description, price);
        return (book, string.Empty);
    }
}