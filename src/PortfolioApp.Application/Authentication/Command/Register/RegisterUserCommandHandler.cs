using MediatR;
using Microsoft.Extensions.Logging;
using PortfolioApp.Application.Authentication.Dtos;
using PortfolioApp.Domain.Common;
using PortfolioApp.Domain.Common.ResultPattern;
using PortfolioApp.Domain.Errors;
using PortfolioApp.Domain.Interfaces;

namespace PortfolioApp.Application.Users.Command.CreateUser;


public class CreateUserCommandHandler(IAuthenticationRepository authenticationRepository,
SanitizeName.SanitizeNameImpl sanitizeName,
 ILogger logger) : IRequestHandler<RegisterUserCommand, Result<Guid>>
{
    public async  Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
       
       logger.LogInformation("Handling Registration for user with email: {Email}", request.Email);
       var sanitizedNames = sanitizeName.SanitizeName(request.FirstName);

       if(!sanitizedNames)
        {
            logger.LogWarning("Invalid name provided");
            return Result.Failure<RegisterResponseDto>;

        }
        var isAdmin = await authenticationRepository.IsAdminExistsAsync();

     if(isAdmin.IsSuccess)
        {
            logger.LogWarning("Admin already exists. Cannot create another admin.");
        }
      var user = await authenticationRepository.RegisterUserAsync(request, request.Password);

    }
}