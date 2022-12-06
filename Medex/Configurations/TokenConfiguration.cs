namespace Medex.Configurations
{
    public class TokenConfiguration
    {
        public string Audience { get; init; } = null!;
        public string Issuer { get; init; } = null!;
        public string Secret { get; init; } = null!;
        public int Minutes { get; set; }
        public int DaysToExpiry{ get; set; }
    }
}
