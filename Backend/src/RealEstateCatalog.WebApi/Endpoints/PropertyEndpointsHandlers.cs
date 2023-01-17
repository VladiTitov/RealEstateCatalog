namespace RealEstateCatalog.WebApi.Endpoints;

internal static class PropertyEndpointsHandlers
{
    internal static async Task<IResult> GetPropertyList(
        int sellRent,
        IUnitOfWork unitOfWork,
        CancellationToken cancellationToken = default)
    {
        var properties = await unitOfWork.PropertyRepository.GetPropertyListBySellRentAsync(sellRent, cancellationToken);
        return properties is not null && properties.Any()
            ? Results.Ok(properties)
            : Results.NoContent();
    }
}
