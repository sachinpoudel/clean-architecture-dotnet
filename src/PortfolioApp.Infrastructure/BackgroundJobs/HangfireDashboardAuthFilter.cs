using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace PortfolioApp.Infrastructure.BackgroundJobs;


public class HangfireDashboardAuthFilter : IDashboardAuthorizationFilter
{
    public bool Authorize([NotNull] DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        return httpContext.User.Identity?.IsAuthenticated ?? false; // check if the user is authenticated, if yes then allow access to the dashboard, otherwise deny access.
    }

    
}