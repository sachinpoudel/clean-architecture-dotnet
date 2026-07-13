using MediatR;
using PortfolioApp.Domain.Common.ResultPattern;

namespace PortfolioApp.Application.Users.Command.CreateUser;


public record RegisterUserCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string Bio,
    string ProfilePicture,
    string Country,
    string City,
    string Headline

) : IRequest<Result<Guid>>;