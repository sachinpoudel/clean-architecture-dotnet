using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Domain.Interfaces;
public interface IProjectRepository : IGenericRepository<Project>
{
    Task<IEnumerable<Project>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}