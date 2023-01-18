namespace RealEstateCatalog.Infrastructure.Persistence.Repositories;

public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PropertyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Property?> GetPropertyDetailAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Property>()
            .Include(i => i.PropertyType)
            .Include(i => i.FurnishingType)
            .Include(i => i.City)
            .Where(i => i.Id.Equals(id))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<Property>> GetPropertyListBySellRentAsync(int sellRent, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Property>()
            .Include(i=>i.PropertyType)
            .Include(i=>i.FurnishingType)
            .Include(i=>i.City)
            .Where(i => i.SellRent.Equals(sellRent))
            .ToListAsync(cancellationToken);
    }
}
