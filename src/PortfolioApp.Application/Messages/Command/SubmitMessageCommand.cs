using MediatR;
using PortfolioApp.Domain.Common.ResultPattern;

namespace PortfolioApp.Application.Messages.Command;



public record SubmitMessageCommand(
    string SenderName,
    string SenderEmail,
    string Subject,
    string Content) : IRequest<Result<string>>;