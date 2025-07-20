using BookStore.Core.Models;

namespace BookStore.DataAccess.Repositories;

public interface IAuthorRepository
{
    Task<Author?> GetByIdAsync(Guid id);
    Task<List<Author>> GetAllAsync();
    Task<Guid> CreateAsync(Author author);
    Task UpdateAsync(Author author);
    Task DeleteAsync(Guid id);
}