using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Application.Messages.Command;
using PortfolioApp.Domain.Common.ResultPattern;
using PortfolioApp.WebApi.Handlers;

namespace PortfolioApp.WebApi.Controller;


[ApiController] 
[Route("api/[controller]")]


public class MessageController(IMediator mediator, ILogger<MessageController> logger) : ControllerBase

{
[HttpPost("submit")] 


public async Task<IActionResult> SubmitMessage(SubmitMessageCommand command)
    {
        var message = new SubmitMessageCommand(
            SenderName: command.SenderName,
            SenderEmail: command.SenderEmail,
            Subject: command.Subject,
            Content: command.Content
        );
        var result = await mediator.Send(message);
        return result.Match(
            success => Ok(success),
            failure => failure.ToActionResult()
        );  
        
}
}
