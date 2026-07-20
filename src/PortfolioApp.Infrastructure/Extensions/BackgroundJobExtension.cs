using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PortfolioApp.Application.Interfaces.Services;
using PortfolioApp.Domain.Options;
using PortfolioApp.Infrastructure.BackgroundJobs;

namespace PortfolioApp.Infrastructure.Extensions;


public static class BackgroundJobExtension
{
    public static IServiceCollection AddBackgroundJob(this IServiceCollection services)
    {
        services.AddHangfire((provider, cfg) =>
        {
            var connectionString = provider.GetRequiredService<IOptions<ConnStringOption>>().Value.PostgresConnectionString;
            var hangfireSettings = provider.GetRequiredService<IOptions<HangfireSettings>>().Value;

            cfg.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(options =>
                {
                    if (string.IsNullOrWhiteSpace(connectionString))
                    {
                        throw new InvalidOperationException("Postgres connection string is not configured.");
                    }

                    options.UseNpgsqlConnection(connectionString);
                });


            services.AddHangfireServer(options =>
            {
                options.WorkerCount = hangfireSettings?.WorkerCount ?? 1;
            });
            services.AddScoped<IBackgroundJobService, HangfireJobService>();
        });





        return services;
    }
}