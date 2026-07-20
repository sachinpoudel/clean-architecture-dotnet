using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {

    services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IMessageRepository, MessageRepository>();
    services.AddScoped<IJwtService, JwtServices>();




// extension configurations
    services.AddFileStorage();
    services.AddEmailService();
    services.AddBackgroundJob();
    return services;
  }
}