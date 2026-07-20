using MediatR;
using Microsoft.Extensions.Logging;
using PortfolioApp.Application.Interfaces;
using PortfolioApp.Application.Interfaces.Services;
using PortfolioApp.Application.Interfaces.UnitofWork;
using PortfolioApp.Domain.Common.ResultPattern;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Domain.Errors;
using Serilog;

namespace PortfolioApp.Application.Users.Command.UploadProfilePicture;



public class UploadProfilePictureHandler(
    IFileStorageService fileStorageService,
    IUnitOfWork unitOfWork,
    ILogger<UploadProfilePictureHandler> logger) : IRequestHandler<UploadProfilePictureCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UploadProfilePictureCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByUserIdAsync(request.UserId, cancellationToken);

        if (user == null)
        {
            return Result<string>.Failure(UserError.UserNotFound(request.UserId));
        }


        var url = await fileStorageService.UploadProfilePictureAsync(request.FileStream, request.FileName, cancellationToken);
        user.SetProfilePicture(url.Value);

        logger.LogInformation("Profile picture uploaded successfully for user {UserId}. URL: {Url}", request.UserId, url.Value);
        await unitOfWork.CommitAsync(cancellationToken);

        return Result<string>.Success(url.Value);
    }
}