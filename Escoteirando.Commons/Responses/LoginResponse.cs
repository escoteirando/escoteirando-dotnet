using Escoteirando.Domain;

namespace Escoteirando.Commons.Responses
{
    public class LoginResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}