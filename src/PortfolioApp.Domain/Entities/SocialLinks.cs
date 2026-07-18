using Microsoft.AspNetCore.Identity;
using PortfolioApp.Domain.Common;
using PortfolioApp.Domain.Interfaces;

namespace PortfolioApp.Domain.Entities;


public class SocialLinks : BaseEntity , IUserEntity
{
 public Guid UserId  {get;set;}
public required string Platform {get;init;}
public required string Url {get;init;}
public string IconUrl {get;init;} = string.Empty;

}