namespace RealEstateCatalog.Core.Application.Interfaces;

public interface IPropertyRepository : IBaseRepository<Property>
{
    Task<Property?> GetPropertyDetailAsync(int id, CancellationToken cancellationToken = default);
    Task<List<Property>> GetPropertyListBySellRentAsync(int sellRent, CancellationToken cancellationToken = default);
}
