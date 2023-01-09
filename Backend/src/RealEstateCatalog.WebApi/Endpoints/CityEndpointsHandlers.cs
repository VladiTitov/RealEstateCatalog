using RealEstateCatalog.Core.Application.Interfaces;

namespace RealEstateCatalog.WebApi.Endpoints;

internal static class CityEndpointsHandlers
{
    internal static async Task<IResult> GetAllAsync(
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken = default)
    {
        var scope = serviceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<ICityRepository>();
        var data = await repository.GetAllAsync(cancellationToken);
        
        return data is null || !data.Any()
            ? Results.NoContent()
            : Results.Ok(data);
    }
}
