using BookStore.Core.Models;

namespace BookStore.BL.Services;

public interface IAuthorService
{
    Task<List<Author>> GetAllAuthors();
    Task<Author?> GetAuthorById(Guid id);
    Task<Guid> CreateAuthor(Author author);
    Task UpdateAuthor(Author author);
    Task DeleteAuthor(Guid id);
}