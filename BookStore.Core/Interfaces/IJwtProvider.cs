using BookStore.Core.Models;

namespace BookStore.Core.JwtProvider;

public interface IJwtProvider
{
    string GenerateToken(User user);
}