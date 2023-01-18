using AutoMapper;

namespace RealEstateCatalog.WebApi.Endpoints;

internal static class PropertyEndpointsHandlers
{
    internal static async Task<IResult> GetPropertyList(
        int sellRent,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        var properties = await unitOfWork.PropertyRepository.GetPropertyListBySellRentAsync(sellRent, cancellationToken);
        return properties is not null && properties.Any()
            ? Results.Ok(mapper.Map<IEnumerable<PropertyListDto>>(properties))
            : Results.NoContent();
    }

    internal static async Task<IResult> GetPropertyDetail(
        int id,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        var property = await unitOfWork.PropertyRepository.GetPropertyDetailAsync(id, cancellationToken);
        return property is not null
            ? Results.Ok(mapper.Map<PropertyDetailDto>(property))
            : Results.NoContent();
    }
}
