using BookStore.BL.Services;
using BookStore.Core.Models;
using BookStore.Core.Interfaces;

namespace BookStore.Core.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<List<User>> GetAllAsync();
    Task<Guid> CreateAsync(RegisterRequesto request);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
}