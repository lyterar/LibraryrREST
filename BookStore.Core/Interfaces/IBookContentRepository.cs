using BookStore.Core.Models;

namespace BookStore.DataAccess.Repositories;

public interface IBookContentRepository
{
    Task<BookContent?> GetByBookIdAsync(Guid bookId);
    Task<Guid> CreateOrUpdateAsync(BookContent content);
    Task<bool> DeleteAsync(Guid bookId);
}