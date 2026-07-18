
namespace PortfolioApp.Application.Interfaces.UnitofWork;


public interface IUnitOfWork
{
 IUserRepository UserRepository { get; }
 Task CommitAsync( CancellationToken cancellationToken = default);
 Task RollbackAsync( CancellationToken cancellationToken = default);
}