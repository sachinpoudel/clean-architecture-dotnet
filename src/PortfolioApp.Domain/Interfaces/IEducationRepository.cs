using PortfolioApp.Domain.Entities;
using PortfolioApp.Domain.Interfaces;

namespace PortfolioApp.Domain.Interfaces;


public interface IEducationRepository: IGenericRepository<Education>
{
    // Task<Education> GetEducationByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Education>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

}