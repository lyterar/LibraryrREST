namespace BookStore.DataAccess.Entities;

public class CommentEntity
{
    public Guid Id { get; set; }

    public Guid BookId { get; set; }
    public BookEntity Book { get; set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }

    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public Guid? ParentCommentId { get; set; }
    public CommentEntity? ParentComment { get; set; }
    public List<CommentEntity> Replies { get; set; } = new();
}