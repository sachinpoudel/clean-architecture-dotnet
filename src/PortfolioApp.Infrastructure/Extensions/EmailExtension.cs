using Microsoft.Extensions.DependencyInjection;
using PortfolioApp.Application.Interfaces.Services;
using PortfolioApp.Domain.Options;
using PortfolioApp.Infrastructure.Services.Email;

namespace PortfolioApp.Infrastructure.Extensions;


public static class EmailExtension
{
    public static IServiceCollection AddEmailService(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, SmtpEmailService>();
        
        return services;
    }
}