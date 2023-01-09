namespace RealEstateCatalog.WebApi.Endpoints;

internal static class CityEndpoints
{
    internal static WebApplication MapCityEnpoints(this WebApplication app)
    {
        app.MapGet(
            pattern: "api/city",
            handler: CityEndpointsHandlers.GetAllAsync)
            .WithName("GetAllCities");

        return app;
    }
}
