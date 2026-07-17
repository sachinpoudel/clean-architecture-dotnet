using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Application.Users.Command.CreateUser;
using PortfolioApp.Domain.Common.ResultPattern;
using PortfolioApp.WebApi.Handlers;

namespace PortfolioApp.WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator, ILogger<AuthController> logger) : ControllerBase
{
    [HttpPost("register")]

    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        logger.LogInformation("Register request received for {Email}", command.Email);
        var result = await mediator.Send(command);
        return result.Match(
            success => CreatedAtAction(nameof(Register), new { id = success.UserId }, success),
            failure => failure.ToActionResult()
        );
    }
}