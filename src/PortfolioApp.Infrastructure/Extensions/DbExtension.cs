using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PortfolioApp.Domain.Options;
using PortfolioApp.Infrastructure.Context;

namespace PortfolioApp.Infrastructure.Extensions;


public static class DbExtension
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {

        services.AddDbContextPool<AppDbContext>((provider, options) =>
        {
            var connectionString = provider.GetRequiredService<IOptions<ConnStringOption>>().Value.PostgresConnectionString;

            if (connectionString is null)
                throw new InvalidOperationException("Postgres connection string is not configured.");

            options.UseNpgsql(connectionString, npgsqloptions =>
            {
                npgsqloptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorCodesToAdd: null
                );
                npgsqloptions.CommandTimeout(60);
            });
        });

//   services.AddHostedService<DatabaseInitializer>();
        return services;
    }
}