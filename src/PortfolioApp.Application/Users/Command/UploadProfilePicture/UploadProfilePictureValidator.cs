using FluentValidation;

namespace PortfolioApp.Application.Users.Command.UploadProfilePicture;


public class UploadProfilePictureValidator : AbstractValidator<UploadProfilePictureCommand>
{

    public  static readonly string[] allowedContentTypes = [
        "image/jpeg",
        "image/png",
        "image/gif"
    ];
public UploadProfilePictureValidator()
    {
        RuleFor(x => x.ContentType)
            .NotEmpty().WithMessage("Content type is required.")
            .Must(contentType => allowedContentTypes.Contains(contentType))
            .WithMessage($"Invalid content type. Allowed types are: {string.Join(", ", allowedContentTypes)}");
            
         RuleFor(x => x.FileStream.Length).LessThanOrEqualTo(5 * 1024 * 1024) // 5 MB
            .WithMessage("File size must be less than or equal to 5 MB.");
    }
}