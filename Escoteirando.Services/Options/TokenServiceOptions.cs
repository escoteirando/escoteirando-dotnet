namespace Escoteirando.Services.Options
{
    public class TokenServiceOptions
    {
        public const string Name = "TokenService";

        public string Secret { get; set; }
        public int ExpirationTimeInHours { get; set; } = 24;
    }
}