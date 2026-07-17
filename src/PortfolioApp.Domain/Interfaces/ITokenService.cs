using PortfolioApp.Domain.Common.ResultPattern;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Domain.Interfaces;


public interface IJwtTokenService
{
 Task<string> GenerateJwtTokenAsync(User user);
  Task<string> GenerateRefreshTokenAsync(); 
  Task<string> GetUserIdFromTokenAsync(string token);
  Task<(string accessToken, string refreshToken)> RefreshTokenAsync(string refreshToken, string accessToken); 
  Task< bool> ValidateCurrentTokenAsync(string token);
  Task<bool> SaveRefreshTokenAsync(User user, string refreshToken);
}