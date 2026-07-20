using Microsoft.EntityFrameworkCore;
using PortfolioApp.Application.Interfaces;
using PortfolioApp.Domain.Interfaces;
using PortfolioApp.Infrastructure.Context;

namespace PortfolioApp.Infrastructure.Repositories;


public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class, IUserEntity
{
    public async Task<T> AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        return entity;
    }

    public Task<T> DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
        
    }

    public async  Task<T> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().FirstOrDefaultAsync(e => e.UserId == userId, cancellationToken);
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}