namespace RealEstateCatalog.WebApi.Endpoints;

internal static class PropertyEndpoints
{
    internal static WebApplication MapPropertyEnpoints(this WebApplication app) 
    {
        app.MapGet(
            pattern: "api/property/type/{sellRent}",
            handler: PropertyEndpointsHandlers.GetPropertyList)
            .WithName("GetAllProperties");
        return app;
    }
}
