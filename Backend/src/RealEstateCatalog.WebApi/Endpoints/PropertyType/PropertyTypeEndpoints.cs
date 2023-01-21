namespace RealEstateCatalog.WebApi.Endpoints.PropertyType;

internal static class PropertyTypeEndpoints
{
    internal static WebApplication MapPropertyTypeEndpoints(this WebApplication app)
    {
        app.MapGet(
            pattern: "api/propertytype/list",
            handler: PropertyTypeEndpointsHandler.GetPropertyTypeList)
            .WithName("GetAllPropertyTypes");
        return app;
    }
}
