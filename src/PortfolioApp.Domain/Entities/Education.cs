
using PortfolioApp.Domain.Interfaces;
using PortfolioApp.Domain.Common;

namespace PortfolioApp.Domain.Entities;

public class Education : BaseEntity, IUserEntity
{
    public Guid UserId {get;set;}
    public required string School {get; init;}
    public required string Degree {get; init;}
    public required string Location {get; init;}
    public string FieldOfStudy {get; init;} = string.Empty;
    public DateOnly StartDate {get; init;}
    public DateOnly? EndDate {get; init;}
    public string Description {get; init;} = string.Empty;
    
}