using BookStore.Core.Models;
using BookStore.DataAccess.Repositories;

namespace BookStore.BL.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public Task<List<Author>> GetAllAuthors() =>
        _authorRepository.GetAllAsync();

    public Task<Author?> GetAuthorById(Guid id) =>
        _authorRepository.GetByIdAsync(id);

    public Task<Guid> CreateAuthor(Author author) =>
        _authorRepository.CreateAsync(author);

    public Task UpdateAuthor(Author author) =>
        _authorRepository.UpdateAsync(author);

    public Task DeleteAuthor(Guid id) =>
        _authorRepository.DeleteAsync(id);
}