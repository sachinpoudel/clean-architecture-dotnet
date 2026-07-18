using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Application.Users.Command.UploadProfilePicture;
using PortfolioApp.Domain.Common.ResultPattern;
using PortfolioApp.WebApi.Extensions;
using PortfolioApp.WebApi.Handlers;

namespace PortfolioApp.WebApi.Controller;


[ApiController]
[Route("api/[controller]")]
public class UploadProfilePictureController(IMediator mediator) : ControllerBase
{
    [HttpPost("me/profile-picture")]
    // [Authorize]
    public async Task<IActionResult> UploadProfilePicture([FromForm] IFormFile file, [FromForm] Guid userId)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        // var userId = User.GetUserId();
        var command = new UploadProfilePictureCommand(
        UserId: userId,
            FileStream: file.OpenReadStream(),
            FileName: file.FileName,
            ContentType: file.ContentType
        );

        var result = await mediator.Send(command);

        return result.Match(
           success => AcceptedAtAction(nameof(UploadProfilePicture), new { url = success }, success),
           failure => failure.ToActionResult()
       );

    }
}