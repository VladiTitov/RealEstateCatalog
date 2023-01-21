using AutoMapper;

namespace RealEstateCatalog.WebApi.Endpoints.Property;

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

    internal static async Task<IResult> CreateProperty(
        PropertyDto propertyDto,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        var property = mapper.Map<Core.Domain.Models.Property>(propertyDto);
        property.PostedBy = 1;
        property.LastUpdatedBy = 1;
        var result = unitOfWork.PropertyRepository.Create(property);
        await unitOfWork.SaveAsync(cancellationToken);

        return result is null
            ? Results.BadRequest()
            : Results.Ok(result);
    }
}
