namespace PortfolioApp.Application.Interfaces;


public interface IGenericRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);

    Task<T> GetByIdAsync(object id, CancellationToken cancellationToken = default);
    Task<T> GetByUserIdAsync(Guid id, CancellationToken cancellationToken = default);

}