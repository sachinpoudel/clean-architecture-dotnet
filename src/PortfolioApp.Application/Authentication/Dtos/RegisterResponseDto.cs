namespace PortfolioApp.Application.Authentication.Dtos;


public record RegisterResponseDto(
    Guid UserId,
   string Email,
   DateTime CreatedAt
   
   
);