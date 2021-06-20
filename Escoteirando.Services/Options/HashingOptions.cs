namespace Escoteirando.Services.Options
{
    public sealed class HashingOptions
    {
        public const string Name = "HashingOptions";
        public int Iterations { get; set; } = 10000;
    }
}