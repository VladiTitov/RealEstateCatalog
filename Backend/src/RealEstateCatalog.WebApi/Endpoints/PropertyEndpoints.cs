namespace RealEstateCatalog.WebApi.Endpoints;

internal static class PropertyEndpoints
{
    internal static WebApplication MapPropertyEnpoints(this WebApplication app) 
    {
        app.MapGet(
            pattern: "api/property/list/{sellRent}",
            handler: PropertyEndpointsHandlers.GetPropertyList)
            .WithName("GetAllProperties");
        app.MapGet(
            pattern: "api/property/detail/{id}",
            handler: PropertyEndpointsHandlers.GetPropertyDetail)
            .WithName("GetPropertyDetail");
        return app;
    }
}
