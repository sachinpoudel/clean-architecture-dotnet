namespace PortfolioApp.Domain.Interfaces;
public interface IUserEntity
{
    Guid Id { get; set; }
    Guid UserId { get; set; }
}