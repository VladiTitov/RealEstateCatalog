namespace RealEstateCatalog.Core.Application.Interfaces;

public interface IPropertyRepository : IBaseRepository<Property>
{
    Task<List<Property>> GetPropertyListBySellRentAsync(int sellRent, CancellationToken cancellationToken = default);
}
