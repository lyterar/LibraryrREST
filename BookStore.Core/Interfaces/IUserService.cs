using BookStore.Core.Models;


namespace BookStore.BL.Services;

public interface IUserService
{
    Task<List<User>> GetAllUsers();
    Task<User?> GetUserById(Guid id);
    Task<Guid> CreateUser(RegisterRequesto user);
    Task UpdateUser(User user);
    Task DeleteUser(Guid id);
    Task<User?> GetUserByEmail(string email);
    Task<string> LoginAsync(LoginRequesto request);
}
public class RegisterRequesto
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
public class LoginRequesto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}