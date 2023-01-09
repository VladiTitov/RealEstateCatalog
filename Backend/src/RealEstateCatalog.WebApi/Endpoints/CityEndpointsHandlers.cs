namespace RealEstateCatalog.WebApi.Endpoints;

internal static class CityEndpointsHandlers
{
    internal static async Task<IResult> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var cities = new [] { "Atlanta", "New York", "Chicago", "Boston"};
        return Results.Ok(cities);
    }
}
