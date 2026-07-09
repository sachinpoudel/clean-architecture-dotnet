namespace PortfolioApp.Domain.Options;


public class ConnStringOption
{
    public const string ConnectionString = "ConnectionStrings";
    public string PostgresConnectionString { get; set; } = string.Empty;
}