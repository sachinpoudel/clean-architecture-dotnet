using PortfolioApp.Domain.Common.ResultPattern;

namespace PortfolioApp.Application.Interfaces.Services;


public interface IFileStorageService
{
    Task<Result<string>> UploadProfilePictureAsync(Stream stream, string fileName, CancellationToken cancellationToken);
    Task DeleteProfilePictureAsync(string publicId,  CancellationToken cancellationToken);
}