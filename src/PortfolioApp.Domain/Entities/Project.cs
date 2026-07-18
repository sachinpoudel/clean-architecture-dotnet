using PortfolioApp.Domain.Common;
using PortfolioApp.Domain.Interfaces;


namespace PortfolioApp.Domain.Entities;
    
public class Project : BaseEntity , IUserEntity
{
    public Guid UserId {get;set;}
    public  required string Title {get;init;}
    public required string Description {get;init;}
    public  string ProjectUrl {get;init;} = string.Empty;
    public required string GihubUrl {get;init;}
    public string ImageUrl {get;init;} = string.Empty;
    public List<string> Technologies {get;init;} = new List<string>();
}