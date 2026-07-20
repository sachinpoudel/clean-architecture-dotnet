
namespace PortfolioApp.Application.Interfaces.UnitofWork;


public interface IUnitOfWork
{
 IUserRepository UserRepository { get; }
 IMessageRepository MessageRepository { get; }
 Task CommitAsync( CancellationToken cancellationToken = default);
 Task RollbackAsync( CancellationToken cancellationToken = default);
}