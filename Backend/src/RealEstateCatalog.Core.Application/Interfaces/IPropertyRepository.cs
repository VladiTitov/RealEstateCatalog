namespace RealEstateCatalog.Core.Application.Interfaces;

public interface IPropertyRepository : IBaseRepository<Property>
{
    Task<IEnumerable<Property>> GetPropertyListBySellRentAsync(int sellRent, CancellationToken cancellationToken = default);
}
