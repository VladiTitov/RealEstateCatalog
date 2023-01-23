namespace RealEstateCatalog.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public ICityRepository CityRepository 
        => new CityRepository(_dbContext);

    public IUserRepository UserRepository 
        => new UserRepository(_dbContext);

    public IPropertyRepository PropertyRepository 
        => new PropertyRepository(_dbContext);

    public IPropertyTypeRepository PropertyTypeRepository 
        => new PropertyTypeRepository(_dbContext);
    public IFurnishingTypeRepository FurnishingTypeRepository 
        => new FurnishingTypeRepository(_dbContext);

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> SaveAsync(CancellationToken cancellationToken)
        => await _dbContext.SaveChangesAsync(cancellationToken) > 0;
}
