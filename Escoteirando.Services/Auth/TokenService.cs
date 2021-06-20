using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Escoteirando.Domain;
using Escoteirando.Domain.Interfaces.Auth;
using Escoteirando.Services.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Escoteirando.Services.Auth
{
    public class TokenService : ITokenService
    {
        private readonly byte[] _tokenKey;
        private readonly int _tokenExpires;

        public TokenService(IOptions<TokenServiceOptions> options)
        {
            if (string.IsNullOrWhiteSpace(options.Value.Secret))
            {
                throw new ApplicationException("Missing TOKEN_SECRET environment variable");
            }

            _tokenKey = Encoding.ASCII.GetBytes(options.Value.Secret);
            _tokenExpires = options.Value.ExpirationTimeInHours;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(_tokenExpires),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}