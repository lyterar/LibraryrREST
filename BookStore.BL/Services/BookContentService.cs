using BookStore.Core.Models;
using BookStore.DataAccess.Repositories;

namespace BookStore.BL.Services;

public class BookContentService : IBookContentService
{
    private readonly IBookContentRepository _bookContentRepository;

    public BookContentService(IBookContentRepository bookContentRepository)
    {
        _bookContentRepository = bookContentRepository;
    }

    public Task<BookContent?> GetContentByBookId(Guid bookId) =>
        _bookContentRepository.GetByBookIdAsync(bookId);

    public Task<Guid> CreateOrUpdateContent(BookContent content) =>
        _bookContentRepository.CreateOrUpdateAsync(content);

    public Task<bool> DeleteContent(Guid bookId) =>
        _bookContentRepository.DeleteAsync(bookId);
}