using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PortfolioApp.Application.Authentication.Dtos;
using PortfolioApp.Domain.Common;
using PortfolioApp.Domain.Common.ResultPattern;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Domain.Errors;
using PortfolioApp.Domain.Interfaces;

namespace PortfolioApp.Application.Users.Command.CreateUser;


public class CreateUserCommandHandler(IAuthenticationRepository authenticationRepository,
SanitizeName.SanitizeNameImpl sanitizeName, IMapper mapper,
 ILogger logger) : IRequestHandler<RegisterUserCommand, Result<RegisterResponseDto>>
{
    public async Task<Result<RegisterResponseDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {

        logger.LogInformation("Handling Registration for user with email: {Email}", request.Email);
        var sanitizedNames = sanitizeName.SanitizeName(request.UserName);

        if (!sanitizedNames)
        {
            logger.LogWarning("Invalid name provided");
            return Result<RegisterResponseDto>.Failure(UserError.InvalidUserName(request.UserName));

        }
        var isAdmin = await authenticationRepository.IsAdminExistsAsync();

        if (isAdmin.IsSuccess)
        {
            logger.LogWarning("Admin already exists. Cannot create another admin.");
        }
        var isEmailTaken = await authenticationRepository.FindByEmailAsync(request.Email);
        if (isEmailTaken != null)
        {
            logger.LogWarning("Email already taken.");
            return Result<RegisterResponseDto>.Failure(UserError.UserAlreadyExists(request.Email));
        }
        var mappedUser = mapper.Map<User>(request);
        var user = await authenticationRepository.RegisterUserAsync(mappedUser, request.Password);

        var result = mapper.Map<RegisterResponseDto>(mappedUser);
        return Result<RegisterResponseDto>.Success(result);

    }
}