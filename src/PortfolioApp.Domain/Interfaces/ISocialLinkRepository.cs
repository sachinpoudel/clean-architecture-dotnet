using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Domain.Interfaces;


public interface ISocialLinkRepository: IGenericRepository<SocialLinks>
{
    Task<IEnumerable<SocialLinks>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}

