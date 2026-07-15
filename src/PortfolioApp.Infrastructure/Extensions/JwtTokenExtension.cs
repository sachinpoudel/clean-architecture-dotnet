using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Domain.Options;
using PortfolioApp.Infrastructure.Context;

namespace PortfolioApp.Infrastructure.Extensions;


public static class JwtTokenExtension
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtConfig").Get<JwtTokenOption>();

        if (jwtSettings is null || string.IsNullOrEmpty(jwtSettings.SecretKey) || string.IsNullOrEmpty(jwtSettings.Issuer) || string.IsNullOrEmpty(jwtSettings.Audience))
        {
            throw new InvalidOperationException("JWT configuration is missing or invalid.");
        }

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

        services.AddIdentity<User, IdentityRole<Guid>>()
          .AddEntityFrameworkStores<AppDbContext>()
          .AddApiEndpoints()
          .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
                   {
                       options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                       options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                       options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                   })
                   .AddJwtBearer("Bearer", options =>
                   {
                       options.RequireHttpsMetadata = false;
                       //options.SaveToken = true;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,
                           ValidIssuer = jwtSettings.Issuer,
                           ValidAudience = jwtSettings.Audience,
                           IssuerSigningKey = secretKey,
                           ClockSkew = TimeSpan.Zero
                       };
                       options.Events = new JwtBearerEvents
                       {
                           OnChallenge = context =>
                           {
                               context.HandleResponse();
                               context.Response.StatusCode = 401;
                               context.Response.ContentType = "application/json";
                               var result = JsonSerializer.Serialize(new
                               {
                                   message = "You are not authorized to access this resource. Please authenticate."
                               });
                               return context.Response.WriteAsync(result);
                           }
                       };
                   });
        // services.AddAuthorizationBuilder()
        //     .AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"))
        //     .SetDefaultPolicy(new AuthorizationPolicyBuilder()
        //         .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        //         .RequireAuthenticatedUser()
        //         .Build());

        return services;
    }
}