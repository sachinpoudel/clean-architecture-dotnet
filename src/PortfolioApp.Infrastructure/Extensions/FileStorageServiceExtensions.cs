// Infrastructure/Storage/FileStorageServiceExtensions.cs
using Microsoft.Extensions.DependencyInjection;
using PortfolioApp.Application.Interfaces.Services;
using PortfolioApp.Domain.Options;
using PortfolioApp.Infrastructure.Storage;

namespace PortfolioApp.Infrastructure.Extensions;

public static class FileStorageServiceExtensions
{
    public static IServiceCollection AddFileStorage(this IServiceCollection services)
    {
        services.AddScoped<IFileStorageService, CloudinaryStorageService>();
        return services;
    }
}