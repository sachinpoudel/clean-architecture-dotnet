using PortfolioApp.Domain.Common;
using PortfolioApp.Domain.Interfaces;


namespace PortfolioApp.Domain.Entities;


public class AboutMe : BaseEntity, IUserEntity
{
    public Guid UserId { get; set; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Headline { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Bio { get; init; } = string.Empty;
    public string ProfilePictureUrl { get; private set; } = string.Empty;
    // public string ProfilePicturePublicId { get; private set; } = string.Empty;


    public string Country { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;



    public AboutMe() { } // this is required by EF Core for materialization



    public void SetProfilePicture(string url)
    {

        if (string.IsNullOrEmpty(url))
        {
            throw new ArgumentException("Profile picture URL cannot be null or empty.");
        }

        ProfilePictureUrl = url;
        // ProfilePicturePublicId = publicId;
    }
}