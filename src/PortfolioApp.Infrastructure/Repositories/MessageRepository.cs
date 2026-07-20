using PortfolioApp.Application.Interfaces;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Infrastructure.Context;

namespace PortfolioApp.Infrastructure.Repositories;

internal sealed class MessageRepository(AppDbContext context) : IMessageRepository
{
    public Task<Message> AddAsync(Message entity)
    {
        throw new NotImplementedException();
    }

    public Task<Message> DeleteAsync(Message entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Message>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Message>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Message> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Message> GetByUserIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetNumberOfUnreadMessagesAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Message> UpdateAsync(Message entity)
    {
        throw new NotImplementedException();
    }
}
