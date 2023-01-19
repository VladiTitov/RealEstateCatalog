namespace RealEstateCatalog.Core.Application.Interfaces.Repositories;

public interface ICityRepository : IBaseRepository<City>
{
    City Create(string cityName);
}
