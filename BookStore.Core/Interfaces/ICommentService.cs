using BookStore.Core.Models;

namespace BookStore.BL.Services;

public interface ICommentService
{
    Task<List<Comment>> GetCommentsByBookId(Guid bookId);
    Task<Comment?> GetCommentById(Guid id);
    Task<Guid> CreateComment(Comment comment);
    Task UpdateComment(Comment comment);
    Task DeleteComment(Guid id);
}