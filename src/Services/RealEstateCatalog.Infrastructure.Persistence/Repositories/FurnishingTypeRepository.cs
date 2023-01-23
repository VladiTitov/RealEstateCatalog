namespace RealEstateCatalog.Infrastructure.Persistence.Repositories;

public class FurnishingTypeRepository : BaseRepository<FurnishingType>, IFurnishingTypeRepository
{
    public FurnishingTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
