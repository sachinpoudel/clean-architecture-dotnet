using PortfolioApp.Domain.Common;
using PortfolioApp.Domain.Interfaces;

namespace PortfolioApp.Domain.Entities;

public class Skills : BaseEntity , IUserEntity
{
    public Guid UserId {get;set;}
    public required string Name {get;init;}
    public string SkillCategory {get;init;} = string.Empty;
    
    public List<string> Technologies {get;init;} = new List<string>();
}
