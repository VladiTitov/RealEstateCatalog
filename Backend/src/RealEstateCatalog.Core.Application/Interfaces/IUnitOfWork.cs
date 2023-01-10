namespace RealEstateCatalog.Core.Application.Interfaces;

public interface IUnitOfWork
{
    ICityRepository CityRepository { get; }
    IUserRepository UserRepository { get; }

    Task<bool> SaveAsync(CancellationToken cancellationToken);
}
