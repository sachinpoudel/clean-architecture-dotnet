using PortfolioApp.Application.Interfaces;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using PortfolioApp.Domain.Options;
using CloudinaryDotNet.Actions;
using PortfolioApp.Domain.Errors;
using PortfolioApp.Domain.Common.ResultPattern;
using PortfolioApp.Application.Interfaces.Services;

namespace PortfolioApp.Infrastructure.Storage;


public class CloudinaryStorageService : IFileStorageService
{

public readonly Cloudinary _cloudinary;
   public CloudinaryStorageService(IOptions<CloudinarySettings> settings) 
    {
        var account = new Account(settings.Value.CloudName, settings.Value.ApiKey, settings.Value.ApiSecret);
        _cloudinary = new Cloudinary(account);
    }





      public async Task DeleteProfilePictureAsync(string publicId, CancellationToken ct)
    {
        var deleteParams = new DeletionParams(publicId);
        await _cloudinary.DestroyAsync(deleteParams);
    }

    public async Task<Result<string>> UploadProfilePictureAsync(Stream stream, string fileName, CancellationToken cancellationToken)
    {
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(fileName, stream),
            Folder = "profile_pictures",
            Transformation = new Transformation().Width(200).Height(200).Crop("fill").Gravity("face")
        };
        var result = await _cloudinary.UploadAsync(uploadParams, cancellationToken);
          if (result  is null)
        {
            
           return Result<string>.Failure(UserError.FailedToUploadProfilePicture());
        }else
        {
            
        return Result<string>.Success(result.SecureUrl.ToString());}
        }


 

}