using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PortfolioApp.Application.Interfaces;
using PortfolioApp.Application.Interfaces.Services;
using PortfolioApp.Application.Interfaces.UnitofWork;
using PortfolioApp.Domain.Options;
using PortfolioApp.Infrastructure.Repositories;
using PortfolioApp.Infrastructure.Services;
using PortfolioApp.Infrastructure.Storage;

namespace PortfolioApp.Infrastructure.Extensions;


public static class InfrastructureExtension
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {

    services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IJwtService, JwtServices>();



    services.AddFileStorage(configuration);
    return services;
  }
}