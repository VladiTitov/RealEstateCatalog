using AutoMapper;

namespace RealEstateCatalog.WebApi.Endpoints.FurnishingType;

internal static class FurnishingTypeEndpointsHandler
{
    internal static async Task<IResult> GetFurnishingTypeList(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        CancellationToken cancellationToken = default)
    {
        var types = await unitOfWork.FurnishingTypeRepository.GetAllAsync(cancellationToken);
        return types is not null && types.Any()
             ? Results.Ok(mapper.Map<IEnumerable<KeyValuePairDto>>(types))
             : Results.NoContent();
    }
}
