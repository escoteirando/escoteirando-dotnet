using System.Threading.Tasks;

namespace Escoteirando.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> FindUserByName(string userName);
    }
}