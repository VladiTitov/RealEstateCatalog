namespace RealEstateCatalog.Infrastructure.Persistence.Repositories;

public class PropertyTypeRepository : BaseRepository<PropertyType>, IPropertyTypeRepository
{
    public PropertyTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
