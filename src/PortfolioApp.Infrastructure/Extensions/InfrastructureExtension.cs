using Microsoft.Extensions.DependencyInjection;
using PortfolioApp.Domain.Interfaces;
using PortfolioApp.Domain.UnitOfWork;
using PortfolioApp.Infrastructure.Repositories;
using PortfolioApp.Infrastructure.Services;

namespace PortfolioApp.Infrastructure.Extensions;


public static class  InfrastructureExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
      
      services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
      services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped< IJwtTokenService ,JwtServices>();


        return services;
    }
}