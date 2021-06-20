using System.Threading.Tasks;
using Escoteirando.Domain;
using Escoteirando.Domain.Interfaces.Auth;
using Escoteirando.Domain.Interfaces.Repositories;

namespace Escoteirando.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _userRepository.FindUserByName(userName);
            if (user is null) return null;
            var (verified, needsUpgrade) = _passwordHasher.Check(user.PasswordHash, password);
            return verified ? user : null;
        }

        public async Task<bool> CreateUser(string userName, string password)
        {
            var passwordHash = _passwordHasher.Hash(password);
            var user = await _userRepository.Save(new User
            {
                Name = userName,
                PasswordHash = passwordHash
            });
            var newUser = await _userRepository.Save(user);
            return newUser is not null;
        }
    }
}