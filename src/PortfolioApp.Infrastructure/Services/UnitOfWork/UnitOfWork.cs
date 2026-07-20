using PortfolioApp.Application.Interfaces;
using PortfolioApp.Application.Interfaces.UnitofWork;
using PortfolioApp.Infrastructure.Context;
using PortfolioApp.Infrastructure.Repositories;

namespace PortfolioApp.Infrastructure.UnitOfWork;

internal sealed class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public IUserRepository UserRepository { get; } = new UserRepository(context); 
    public IMessageRepository MessageRepository { get; } = new MessageRepository(context); 
    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await context.DisposeAsync();
    }
}