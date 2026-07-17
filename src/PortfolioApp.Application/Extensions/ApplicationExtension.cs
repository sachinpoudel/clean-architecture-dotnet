using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using PortfolioApp.Domain.Common;

namespace PortfolioApp.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {


        var applicationAssembly = typeof(ApplicationExtension).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        services.AddAutoMapper(cfg => { }, typeof(ApplicationExtension));

        services.AddScoped<ISanitizeName , SanitizeName>();
        return services;
    }
}