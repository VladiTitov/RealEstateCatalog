namespace RealEstateCatalog.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public ICityRepository CityRepository 
        => new CityRepository(_dbContext);

    public IUserRepository UserRepository 
        => new UserRepository(_dbContext);

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> SaveAsync(CancellationToken cancellationToken)
        => await _dbContext.SaveChangesAsync(cancellationToken) > 0;
}
