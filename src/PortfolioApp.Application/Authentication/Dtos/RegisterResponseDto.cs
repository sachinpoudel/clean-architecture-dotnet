namespace PortfolioApp.Application.Authentication.Dtos;


public record RegisterResponseDto(
    Guid UserId,
   string Email,
   DateTime CreatedAt,
   string AccessToken,
   string RefreshToken
   
   
);