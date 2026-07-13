using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Domain.Interfaces;

public interface ISkillRepository : IGenericRepository<Skills>
{
    Task<IEnumerable<Skills>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}