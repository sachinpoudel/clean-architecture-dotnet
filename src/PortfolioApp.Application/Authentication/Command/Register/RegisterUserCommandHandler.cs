using MediatR;
using Microsoft.Extensions.Logging;
using PortfolioApp.Application.Authentication.Dtos;
using PortfolioApp.Application.Users.Command.CreateUser;
using PortfolioApp.Domain.Common;
using PortfolioApp.Domain.Common.ResultPattern;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Domain.Errors;
using PortfolioApp.Domain.Interfaces;

namespace PortfolioApp.Application.Authentication.Command.Register;


public class RegisterUserCommandHandler(IAuthenticationRepository authenticationRepository,
ISanitizeName sanitizeName, IJwtTokenService jwtService,
 ILogger<RegisterUserCommandHandler> logger) : IRequestHandler<RegisterUserCommand, Result<RegisterResponseDto>>
{
    public async Task<Result<RegisterResponseDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {

        logger.LogInformation("Handling Registration for user with email: {Email}", request.Email);
        var sanitizedNames = sanitizeName.Execute(request.UserName);

        if (!sanitizedNames)
        {
            logger.LogWarning("Invalid name provided");
            return Result<RegisterResponseDto>.Failure(UserError.InvalidUserName(request.UserName));

        }
        var isAdmin = await authenticationRepository.IsAdminExistsAsync();

        if (isAdmin.IsSuccess && isAdmin.Value)
        {
            logger.LogWarning("Admin already exists. Cannot create another admin.");
        }
        var isEmailTaken = await authenticationRepository.FindByEmailAsync(request.Email);
        if (isEmailTaken.IsSuccess)
        {
            logger.LogWarning("Email already taken.");
            return Result<RegisterResponseDto>.Failure(UserError.UserAlreadyExists(request.Email));
        }
        var mappedUser = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            AboutMe = new AboutMe
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Bio = request.Bio,
                ProfilePicture = request.ProfilePicture,
                Country = request.Country,
                City = request.City,
                Headline = request.Headline
            }
        };

        var user = await authenticationRepository.RegisterUserAsync(mappedUser, request.Password);

        if (user.IsFailure)
        {
            return Result<RegisterResponseDto>.Failure(user.Error!);
        }

        var accessToken = await jwtService.GenerateJwtTokenAsync(user.Value);

        var refreshToken = await jwtService.GenerateRefreshTokenAsync();

        // user.Value.RefreshToken = refreshToken;
        // user.Value.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

        await jwtService.SaveRefreshTokenAsync(user.Value, refreshToken);


        var result = new RegisterResponseDto(user.Value.Id, user.Value.Email!, DateTime.UtcNow, accessToken, refreshToken);
        return Result<RegisterResponseDto>.Success(result);

    }
}