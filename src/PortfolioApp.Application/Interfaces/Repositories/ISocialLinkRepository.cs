using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Interfaces;


public interface ISocialLinkRepository: IGenericRepository<SocialLinks>
{
    Task<IEnumerable<SocialLinks>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}

