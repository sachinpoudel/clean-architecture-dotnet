using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Application.Interfaces;
using PortfolioApp.Domain.Options;
using PortfolioApp.Application.Interfaces.Services;

namespace PortfolioApp.Infrastructure.Services;


public class JwtServices(

    IOptions<JwtTokenOption> jwtOptions,
    UserManager<User> userManager,
    ILogger<JwtServices> logger
) : IJwtService
{
    private readonly JwtTokenOption jwtTokenOption = jwtOptions.Value;
    public async Task<string> GenerateJwtTokenAsync(User user)
    {


        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenOption.SecretKey));

        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var claims = await GetClaimsAsync(user);

        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var jwtToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        logger.LogInformation("JWT token generated for user {UserId} with expiration {Expiration}", user.Id, tokenOptions.ValidTo);
        return jwtToken;

    }


    //get userId from token


    public async Task<string?> GetUserIdFromTokenAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            logger.LogWarning("Token is null or empty.");
            return null;
        }

        try
        {
            token = token.Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase); // remove Bearer prefix if present

            var tokenHandler = new JwtSecurityTokenHandler(); // this is the correct handler for JWT tokens
            var validateParameters = GetValidationParameters();
            var principal = tokenHandler.ValidateToken(token, validateParameters, out var validatedToken);
            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var guidUserId))
            {
                logger.LogWarning("User ID claim is missing or invalid in the token.");
                return null;
            }
            return userId;

        }
        catch (System.Exception)
        {
            logger.LogError("Error occurred while processing token.");
            throw;
        }
    }

    public async Task<bool> ValidateCurrentTokenAsync(string token)
    {
        try
        {
            if (string.IsNullOrEmpty(token)) return false;
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            handler.ValidateToken(token, validationParameters, out _);
            return true;
        }
        catch
        {
            return false;
        }
    }


    public async Task<(string accessToken, string refreshToken)> RefreshTokenAsync(string refreshToken, string accessToken)
    {
        try
        {
            var userId = await GetUserIdFromTokenAsync(accessToken);
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                throw new UnauthorizedAccessException("User not found");


            if (refreshToken != user.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new UnauthorizedAccessException("Invalid or expired refresh token");
            }
            var newAccessToken = await GenerateJwtTokenAsync(user);
            var newRefreshToken = await GenerateRefreshTokenAsync();
            await SaveRefreshTokenAsync(user, newRefreshToken);

            return (newAccessToken, newRefreshToken);
        }
        catch (System.Exception)
        {
            logger.LogInformation("Error occurred while refreshing token.");
            throw;
        }

    }


    public async Task<bool> SaveRefreshTokenAsync(User user, string refreshToken)
    {
        try
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(jwtOptions.Value.RefreshTokenExpirationDays);

            var result = await userManager.UpdateAsync(user);
            return result.Succeeded;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to save refresh token for user: {UserId}", user.Id);
            return false;
        }
    }



    public async Task<string> GenerateRefreshTokenAsync()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        return new JwtSecurityToken(
            jwtOptions.Value.Issuer,
            jwtOptions.Value.Audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(jwtOptions.Value.AccessTokenExpirationMinutes),
            signingCredentials: signingCredentials
        );
    }

    private async Task<List<Claim>> GetClaimsAsync(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName!),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email!),
            new(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            // new("FirstName", user.AboutMe.FirstName),
            // new("LastName", user.AboutMe.LastName)
        };

        var roles = await userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        return claims;
    }

    private TokenValidationParameters GetValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey!)),
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Value.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtOptions.Value.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    }
}