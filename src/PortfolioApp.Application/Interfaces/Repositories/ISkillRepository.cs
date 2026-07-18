using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Interfaces;

public interface ISkillRepository : IGenericRepository<Skills>
{
    Task<IEnumerable<Skills>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}