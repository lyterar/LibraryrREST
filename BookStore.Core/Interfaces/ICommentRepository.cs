using BookStore.Core.Models;

namespace BookStore.DataAccess.Repositories;

public interface ICommentRepository
{
    Task<Comment?> GetByIdAsync(Guid id);
    Task<List<Comment>> GetByBookIdAsync(Guid bookId);
    Task<Guid> CreateAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(Guid id);
}