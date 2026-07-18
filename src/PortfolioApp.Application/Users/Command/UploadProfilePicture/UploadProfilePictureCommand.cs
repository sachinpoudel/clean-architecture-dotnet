using MediatR;
using PortfolioApp.Domain.Common.ResultPattern;

namespace PortfolioApp.Application.Users.Command.UploadProfilePicture;


public record UploadProfilePictureCommand(
    Guid UserId,
    Stream FileStream, // 
    string FileName,
    string ContentType) : IRequest<Result<string>>;
