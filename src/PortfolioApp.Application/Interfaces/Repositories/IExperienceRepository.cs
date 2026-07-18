using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Interfaces;


public interface IExperienceRepository: IGenericRepository<Experience>
{
    Task<IEnumerable<Experience>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}