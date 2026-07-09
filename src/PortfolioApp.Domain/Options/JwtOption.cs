namespace PortfolioApp.Domain.Options;

public class JwtTokenOption
{
    public const string JwtConfig = "JwtConfig";
    public string SecretKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public double AccessTokenExpirationMinutes { get; set; }
    public int RefreshTokenExpirationDays { get; set; }
}