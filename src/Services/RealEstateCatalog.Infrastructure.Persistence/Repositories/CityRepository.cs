namespace RealEstateCatalog.Infrastructure.Persistence.Repositories;

public class CityRepository : BaseRepository<City>, ICityRepository
{
    public CityRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public City Create(string cityName)
    {
        var city = new City
        {
            Name = cityName,
            LastUpdatedBy = 1,
            LastUpdatedOn = DateTime.Now
        };
        base.Create(city);
        return city;
    }
}
