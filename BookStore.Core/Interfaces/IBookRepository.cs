using BookStore.Core.Models;

namespace BookStore.DataAccess.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooks();
    Task<Guid> Create(Book book);
    Task<Guid> Update(Guid id ,string title ,string description ,decimal price);
    Task<Guid> Delete(Guid id);
}