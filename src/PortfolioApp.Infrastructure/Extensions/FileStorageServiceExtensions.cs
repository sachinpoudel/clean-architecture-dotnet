// Infrastructure/Storage/FileStorageServiceExtensions.cs
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortfolioApp.Application.Interfaces.Services;
using PortfolioApp.Domain.Options;
using PortfolioApp.Infrastructure.Storage;

namespace PortfolioApp.Infrastructure.Extensions;

public static class FileStorageServiceExtensions
{
    public static IServiceCollection AddFileStorage(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
        services.AddScoped<IFileStorageService, CloudinaryStorageService>();
        return services;
    }
}