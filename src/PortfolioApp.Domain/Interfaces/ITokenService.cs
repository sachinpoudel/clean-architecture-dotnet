using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Domain.Interfaces;


public interface ITokenRepository
{
 Task<string> GenerateJwtTokenAsync(User user);
  string GenerateRefreshToken(); 
  Guid GetUserIdFromToken(string token);
  Task<(string accessToken, string refreshToken)> RefreshTokenAsync(string refreshToken); 
  bool ValidateCurrentToken(string token);
}