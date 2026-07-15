using PortfolioApp.Domain.Interfaces;

namespace PortfolioApp.Domain.UnitOfWork;


public interface IUnitOfWork
{
 IUserRepository UserRepository { get; }
 Task CommitAsync( CancellationToken cancellationToken = default);
 Task RollbackAsync( CancellationToken cancellationToken = default);
}