using System.Text.Json.Serialization;

namespace BookStore.Core.Models;

public class Comment
{
    public const int MAX_TEXT_LENGTH = 1000;

    [JsonConstructor]
    public Comment(Guid id, Guid bookId, Guid userId, string text, DateTime createdAt, Guid? parentCommentId)
    {
        Id = id;
        BookId = bookId;
        UserId = userId;
        Text = text;
        CreatedAt = createdAt;
        ParentCommentId = parentCommentId;
    }

    public Guid Id { get; }
    public Guid BookId { get; }
    public Guid UserId { get; }
    public string Text { get; } = string.Empty;
    public DateTime CreatedAt { get; }
    public Guid? ParentCommentId { get; }

    public static (Comment? Comment, string Error) Create(Guid id, Guid bookId, Guid userId, string text, Guid? parentCommentId = null)
    {
        if (string.IsNullOrWhiteSpace(text) || text.Length > MAX_TEXT_LENGTH)
        {
            return (null, "Comment cannot be empty or longer than 1000 characters.");
        }

        var comment = new Comment(id, bookId, userId, text, DateTime.UtcNow, parentCommentId);
        return (comment, string.Empty);
    }
}