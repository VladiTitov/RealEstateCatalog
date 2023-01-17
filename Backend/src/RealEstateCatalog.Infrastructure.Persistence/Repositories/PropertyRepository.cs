namespace RealEstateCatalog.Infrastructure.Persistence.Repositories;

public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
{
    public PropertyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<IEnumerable<Property>> GetPropertyListBySellRentAsync(int sellRent, CancellationToken cancellationToken = default)
    {
        var data = await base.GetAllAsync(cancellationToken);
        var filteredData = data.Where(i => i.SellRent.Equals(sellRent));
        return filteredData;
    }
}
