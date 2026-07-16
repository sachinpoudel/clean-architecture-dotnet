using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Application.Users.Command.CreateUser;

namespace PortfolioApp.WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("/register")]

    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}