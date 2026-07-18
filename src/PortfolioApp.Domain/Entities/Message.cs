using PortfolioApp.Domain.Common;
using PortfolioApp.Domain.Interfaces;

namespace PortfolioApp.Domain.Entities;

public class Message : BaseEntity, IUserEntity
{
    public Guid UserId {get;set;}
public required string SenderName {get; init;}
    public required string SenderEmail {get; init;}
    public required string Subject {get; init;}
    public required string Content {get; init;}
    public DateTime SendAt {get; init;} = DateTime.UtcNow;
    public bool IsRead {get;set;} = false;
}