using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escoteirando.Domain;
using Escoteirando.Domain.Enums;
using Escoteirando.Domain.Interfaces.Repositories;
using Escoteirando.Domain.ValueObjects;
using Escoteirando.Services.Auth;
using Escoteirando.Services.Options;
using Microsoft.Extensions.Options;

namespace Escoteirando.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();

        public UserRepository()
        {
            _users.AddRange(new[]
            {
                new User
                {
                    Apelido = "Guionardo", Cpf = new CPF("96980389904"), Id = 1, Name = "guionardo",
                    PasswordHash = "1234", Role = UserRole.Admin
                },
                new User()
                {
                    Name = "gui",
                    PasswordHash = "10000.8VyyWC6TbuKs07hIuReptw==.QpmSsoli5QpliqLGFYmvPul/j6UzFu9US0csp9w+iYg="
                }
            });
        }

        public async Task<User> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Save(User entity)
        {
            var user = await FindUserByName(entity.Name);
            if (user is null)
            {
                _users.Add(entity);
                return entity;
            }

            return user;
        }

        public async Task<User> FindUserByName(string userName)
        {
            var user = _users.FirstOrDefault(x => x.Name == userName);
            return user;
        }
    }
}