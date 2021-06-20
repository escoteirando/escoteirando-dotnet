using Escoteirando.Domain.Interfaces.Auth;
using Escoteirando.Domain.Interfaces.Repositories;
using Escoteirando.Services.Auth;
using Escoteirando.Services.Options;
using Escoteirando.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Escoteirando.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEscoteirandoServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ITokenService, TokenService>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IPasswordHasher, PasswordHasher>()
                .AddScoped<IAuthService, AuthService>();
        }
    }
}