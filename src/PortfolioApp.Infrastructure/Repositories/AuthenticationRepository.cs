using Microsoft.AspNetCore.Identity;
using PortfolioApp.Domain.Common.ResultPattern;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Domain.Errors;
using PortfolioApp.Domain.Enums;
using PortfolioApp.Application.Interfaces;

namespace PortfolioApp.Infrastructure.Repositories;


public class AuthenticationRepository(

  UserManager<User> userManager,

RoleManager<IdentityRole<Guid>> roleManager,
SignInManager<User> signInManager


) : IAuthenticationRepository
{
    public Task<Result<bool>> AssignRoleAsync(User user, string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<Result<User>> ChangePasswordAsync(User user, string currentPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task<Result<User>> DeleteUserAsync(Guid UserId)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<User>> FindByEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user is null)
        {
            return Result<User>.Failure(UserError.UserAlreadyExists(email));
        }

        return Result<User>.Success(user);
    }

    public async Task<Result<bool>> IsAdminExistsAsync()
    {
        var usersInRole = await userManager.GetUsersInRoleAsync(UserRole.Admin.ToString());
        return Result<bool>.Success(usersInRole.Any());
    }

    public Task<Result<bool>> IsInRoleAsync(User user, string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<Result<User>> LoginUserAsync(User request, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<User>> RegisterUserAsync(User request, string password)
    {
        if (await userManager.FindByEmailAsync(request.Email!) is not null)
        {
            return Result<User>.Failure(UserError.UserAlreadyExists(request.Email));
        }

        var identityResult = await userManager.CreateAsync(request, password);



        if (identityResult.Succeeded)
        {
            return Result<User>.Success(request);
        }
        return Result<User>.Failure(UserError.FailedToCreateUser(request.Email));

    }

    public Task<Result<User>> UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}

