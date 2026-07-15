using PortfolioApp.Domain.Common;
using PortfolioApp.Domain.UnitOfWork;

namespace PortfolioApp.Domain.Entities;

public class Experience : BaseEntity, IUserEntity
{
    public Guid UserId {get;set;}
    public required string Title {get; init;}
    public required string Company {get;init;}
    public DateOnly StartDate {get;init;}
    public DateOnly? EndDate {get;init;}
    public string Description {get;init;} = string.Empty;
    public string Location {get;init;} = string.Empty;
}