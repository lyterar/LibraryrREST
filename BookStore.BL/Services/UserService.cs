using BookStore.Core.Interfaces;
using BookStore.Core.JwtProvider;
using BookStore.Core.Models;
using BookStore.Core.PasswordHasher;



namespace BookStore.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        
        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher,IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider=jwtProvider;
        }

        public Task<List<User>> GetAllUsers() =>
            _userRepository.GetAllAsync();

        public Task<User?> GetUserById(Guid id) =>
            _userRepository.GetByIdAsync(id);

        public Task<Guid> CreateUser(RegisterRequesto user) =>
            _userRepository.CreateAsync(user);

        public Task UpdateUser(User user) =>
            _userRepository.UpdateAsync(user);

        public Task DeleteUser(Guid id) =>
            _userRepository.DeleteAsync(id);

        public Task<User?> GetUserByEmail(string email) =>
            _userRepository.GetByEmailAsync(email);

   
      

        public async Task<string> LoginAsync(LoginRequesto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
                throw new UnauthorizedAccessException("Пользователь с таким email не найден.");

            var passwordValid = _passwordHasher.Verify(request.Password, user.PasswordHash);
            if (!passwordValid)
                throw new UnauthorizedAccessException("Неверный пароль.");

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }


    }
}