using RealEstateCatalog.Core.Domain.Models;
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
        var response = await repository.GetAllAsync(cancellationToken);
        
        return response is null || !response.Any()
            ? Results.NoContent()
            : Results.Ok(response);
    }

    internal static async Task<IResult> GetByIdAsync(
        int id,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken = default)
    {
        var scope = serviceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<ICityRepository>();
        var response = await repository.GetByIdAsync(id, cancellationToken);

        return response is null
            ? Results.NoContent()
            : Results.Ok(response);
    }

    internal static async Task<IResult> CreateAsync(
        string cityName,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken = default)
    {
        var city = new City { Name = cityName };

        var scope = serviceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<ICityRepository>();
        var response = await repository.CreateAsync(city, cancellationToken);

        return response is City cityResult
            ? Results.Created($"api/city/{cityResult.Id}", cityResult)
            : Results.BadRequest();
    }

    internal static async Task<IResult> UpdateAsync(
        City city,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken = default)
    {
        var scope = serviceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<ICityRepository>();
        var entity = await repository.GetByIdAsync(city.Id, cancellationToken);
        if (entity is null) return Results.NotFound();
        await repository.UpdateAsync(city, cancellationToken);
        return Results.Ok();
    }

    internal static async Task<IResult> DeleteAsync(
        int id,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken = default)
    {
        var scope = serviceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<ICityRepository>();
        var entity = await repository.GetByIdAsync(id, cancellationToken);
        if (entity is null) return Results.NotFound();

        await repository.DeleteAsync(entity, cancellationToken);
        return Results.NoContent();
    }
}
