using System.Threading.Tasks;

namespace Escoteirando.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        Task<T> Get(int id);
        Task<T> Save(T entity);
    }
}