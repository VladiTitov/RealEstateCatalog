namespace RealEstateCatalog.WebApi.Endpoints.City;

internal static class CityEndpoints
{
    internal static WebApplication MapCityEnpoints(this WebApplication app)
    {
        app.MapGet(
            pattern: "api/city",
            handler: CityEndpointsHandlers.GetAllAsync)
            .WithName("GetAllCities");

        app.MapGet(
            pattern: "api/city/{id}",
            handler: CityEndpointsHandlers.GetByIdAsync)
            .WithName("GetByIdAsync");

        app.MapPut(
            pattern: "api/city",
            handler: CityEndpointsHandlers.UpdateAsync)
            .WithName("UpdateAsync");

        app.MapPost(
            pattern: "api/city",
            handler: CityEndpointsHandlers.CreateAsync)
            .WithName("CreateAsync");

        app.MapDelete(
            pattern: "api/city/{id}",
            handler: CityEndpointsHandlers.DeleteAsync)
            .WithName("DeleteAsync");

        return app;
    }
}
