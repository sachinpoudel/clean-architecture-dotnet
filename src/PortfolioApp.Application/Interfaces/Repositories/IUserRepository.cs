using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Interfaces;


public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetUserDetails(string email, CancellationToken cancellationToken = default);
}