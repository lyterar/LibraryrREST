using BookStore.Core.Models;

namespace BookStore.BL.Services;

public interface IBookContentService
{
    Task<BookContent?> GetContentByBookId(Guid bookId);
    Task<Guid> CreateOrUpdateContent(BookContent content);
    Task<bool> DeleteContent(Guid bookId);
}