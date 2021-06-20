using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Escoteirando.Domain.Interfaces.Auth
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        
    }
}