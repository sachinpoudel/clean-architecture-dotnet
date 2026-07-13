using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Domain.Interfaces;

public interface IMessageRepository : IGenericRepository<Message>
{
    Task<IEnumerable<Message>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<int> GetNumberOfUnreadMessagesAsync(Guid userId, CancellationToken cancellationToken = default);
}