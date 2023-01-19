using AutoMapper;

namespace RealEstateCatalog.WebApi.Endpoints.PropertyType;

internal class PropertyTypeEndpointsHandler
{
    internal static async Task<IResult> GetPropertyTypeList(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        var types = await unitOfWork.PropertyTypeRepository.GetAllAsync(cancellationToken);
        return types is not null && types.Any()
             ? Results.Ok(mapper.Map<IEnumerable<KeyValuePairDto>>(types))
             : Results.NoContent();
    }
}
