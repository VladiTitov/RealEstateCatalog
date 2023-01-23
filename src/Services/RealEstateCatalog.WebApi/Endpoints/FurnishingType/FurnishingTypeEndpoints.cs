namespace RealEstateCatalog.WebApi.Endpoints.FurnishingType;

internal static class FurnishingTypeEndpoints
{
    internal static WebApplication MapFurnishingTypeEndpoints(this WebApplication app)
    {
        app.MapGet(
            pattern: "api/furnishingtype/list",
            handler: FurnishingTypeEndpointsHandler.GetFurnishingTypeList)
            .WithName("GetAllFurnishingTypes");
        return app;
    }
}
