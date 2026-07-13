using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Domain.Interfaces;


public interface IExperienceRepository: IGenericRepository<Experience>
{
    Task<IEnumerable<Experience>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}