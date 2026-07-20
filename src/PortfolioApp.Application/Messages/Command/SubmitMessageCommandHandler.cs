using MediatR;
using Microsoft.Extensions.Logging;
using PortfolioApp.Application.Interfaces.Services;
using PortfolioApp.Application.Interfaces.UnitofWork;
using PortfolioApp.Domain.Common.ResultPattern;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Messages.Command;


public class SubmitMessageHandler(IBackgroundJobService backgroundJobService, IUnitOfWork unitOfWork, ILogger<SubmitMessageHandler> logger) : IRequestHandler<SubmitMessageCommand, Result<string>>
{
    public async Task<Result<string>> Handle(SubmitMessageCommand request, CancellationToken cancellationToken)
    {
       var message = new Message
       {
           SenderName = request.SenderName,
           SenderEmail = request.SenderEmail,
           Subject = request.Subject,
           Content = request.Content,
           SendAt = DateTime.UtcNow
       };

        var result = await unitOfWork.MessageRepository.AddAsync(message);
          await unitOfWork.CommitAsync(cancellationToken);

          backgroundJobService.Enqueue<IEmailService>(x => x.SendEmailAsync(message.SenderEmail, message.Subject, message.Content, cancellationToken)); 
          logger.LogInformation("Message submitted successfully. Sender: {SenderEmail}, Subject: {Subject}", message.SenderEmail, message.Subject);
          return Result<string>.Success("Message submitted successfully.");

    }
}