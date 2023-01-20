namespace RealEstateCatalog.WebApi.Endpoints.Property;

internal static class PropertyEndpoints
{
    internal static WebApplication MapPropertyEndpoints(this WebApplication app)
    {
        app.MapGet(
            pattern: "api/property/list/{sellRent}",
            handler: PropertyEndpointsHandlers.GetPropertyList)
            .WithName("GetAllProperties");
        app.MapGet(
            pattern: "api/property/detail/{id}",
            handler: PropertyEndpointsHandlers.GetPropertyDetail)
            .WithName("GetPropertyDetail");
        app.MapPost(
            pattern: "api/property",
            handler: PropertyEndpointsHandlers.CreateProperty)
            .WithName("CreateProperty");
        return app;
    }
}
