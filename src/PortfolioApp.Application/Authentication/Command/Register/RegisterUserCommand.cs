using MediatR;
using PortfolioApp.Application.Authentication.Dtos;
using PortfolioApp.Domain.Common.ResultPattern;

namespace PortfolioApp.Application.Users.Command.CreateUser;


public record RegisterUserCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
string Password,
    string Bio,
    string ProfilePicture,
    string Country,
    string City,
    string Headline

) : IRequest<Result<RegisterResponseDto>>;