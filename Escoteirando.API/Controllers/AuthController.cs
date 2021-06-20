using System.Threading.Tasks;
using Escoteirando.Commons.Requests;
using Escoteirando.Commons.Responses;
using Escoteirando.Domain;
using Escoteirando.Domain.Interfaces.Auth;
using Escoteirando.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escoteirando.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthService authorizationService, ITokenService tokenService)
        {
            _authService = authorizationService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var user = await _authService.Login(request.UserName, request.Password);
            if (user is null)
                return Unauthorized(new LoginResponse
                {
                    Message = "Wrong user or password",
                    Token = null,
                    User = null
                });
            var token = _tokenService.GenerateToken(user);
            return Ok(new LoginResponse
            {
                Message = "OK",
                Token = token,
                User = user
            });
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(string userName, string password)
        {
            var success = await _authService.CreateUser(userName, password);
            if (success)
                return Ok();
            return BadRequest();
        }
    }
}