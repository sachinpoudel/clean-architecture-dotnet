using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Extensions.Options;
using PortfolioApp.Domain.Options;
using PortfolioApp.Infrastructure.BackgroundJobs;

namespace PortfolioApp.WebApi.Extensions;

public static class HangfireExtensions
{
    public static IApplicationBuilder UsePortfolioHangfireDashboard(
        this IApplicationBuilder app)
    {
        var settings = app.ApplicationServices
            .GetRequiredService<IOptions<HangfireSettings>>()
            .Value;

      app.UseHangfireDashboard(settings.DashboardPath, new DashboardOptions
{
    Authorization = new[] { new HangfireDashboardAuthFilter() },
    DashboardTitle = "Portfolio Background Jobs"
});

        return app;
    }
}