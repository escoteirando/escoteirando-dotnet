using System.Threading.Tasks;

namespace Escoteirando.Domain.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<User> Login(string userName, string password);
        Task<bool> CreateUser(string userName, string password);
    }
}