using PortfolioApp.Domain.Common;
using PortfolioApp.Domain.UnitOfWork;

namespace PortfolioApp.Domain.Entities;


public class AboutMe : BaseEntity, IUserEntity{
    public Guid UserId {get;set;}
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Headline { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Bio { get; init; } = string.Empty;
    public string ProfilePicture { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
}