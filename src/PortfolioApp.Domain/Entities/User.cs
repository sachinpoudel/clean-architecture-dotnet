using Microsoft.AspNetCore.Identity;
using PortfolioApp.Domain.Interfaces;
// using PortfolioApp.Domain.UnitOfWork;
namespace PortfolioApp.Domain.Entities;



public class User : IdentityUser<Guid>, IUserEntity
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    // public string? PasswordHash { get; set; }
    // public string? PasswordSalt { get; set; }

public AboutMe AboutMe {get;set;} = new AboutMe();
public ICollection<Education> Educations {get;set;} = new List<Education>();
public ICollection<Experience> Experiences {get;set;} = new List<Experience>();
public ICollection<Project> Projects {get;set;} = new List<Project>();
public ICollection<Skills> Skills {get;set;} = new List<Skills>();
public ICollection<SocialLinks> SocialLinks {get;set;} = new List<SocialLinks>();
public ICollection<Message> Certifications {get;set;} = new List<Message>();

    Guid IUserEntity.UserId
    {
        get => Id;
        set => Id = value;
    }
    public void SetProfilePicture(string url, string publicId)
    {
        AboutMe.SetProfilePicture(url, publicId);
    }
}

