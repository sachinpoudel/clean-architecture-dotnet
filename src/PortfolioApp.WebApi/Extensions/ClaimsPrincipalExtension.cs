// webapi/Extensions/ClaimsPrincipalExtensions.cs
using System.Security.Claims;

namespace PortfolioApp.WebApi.Extensions;
public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var id = user.FindFirstValue(ClaimTypes.NameIdentifier);
        return id is null ? throw new UnauthorizedAccessException() : Guid.Parse(id);
    }
}