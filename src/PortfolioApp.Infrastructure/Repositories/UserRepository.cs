using PortfolioApp.Domain.Entities;
using PortfolioApp.Application.Interfaces;
using PortfolioApp.Infrastructure.Context;

namespace PortfolioApp.Infrastructure.Repositories;


public class UserRepository(AppDbContext context)
    : IGenericRepository<User>, IUserRepository
{
    public Task<User> AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByUserIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserDetails(string email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}