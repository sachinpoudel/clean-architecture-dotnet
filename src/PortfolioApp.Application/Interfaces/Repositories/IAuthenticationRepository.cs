using PortfolioApp.Domain.Common.ResultPattern;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Interfaces;

public interface IAuthenticationRepository
{
    Task<Result<User>> RegisterUserAsync(User request , string password); 
    Task<Result<User>> UpdateUserAsync(User  user);
    Task<Result<User>> LoginUserAsync(User request, string password); 
    Task<Result<User>> FindByEmailAsync(string email);
    Task<Result<User>> ChangePasswordAsync(User user, string currentPassword, string newPassword);
    Task<Result<User>> DeleteUserAsync(Guid UserId); 
    Task<Result<bool>> IsInRoleAsync(User user, string roleName);
    Task<Result<bool>> IsAdminExistsAsync();
    Task<Result<bool>> AssignRoleAsync(User user, string roleName);


}