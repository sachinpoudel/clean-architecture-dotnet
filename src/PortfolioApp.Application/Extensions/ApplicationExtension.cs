using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace PortfolioApp.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {


        var applicationAssembly = typeof(ApplicationExtension).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        services.AddAutoMapper(cfg => { }, typeof(ApplicationExtension));
        return services;
    }
}