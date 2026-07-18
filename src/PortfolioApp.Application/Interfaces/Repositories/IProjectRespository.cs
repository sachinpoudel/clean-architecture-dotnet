using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Interfaces;
public interface IProjectRepository : IGenericRepository<Project>
{
    Task<IEnumerable<Project>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}