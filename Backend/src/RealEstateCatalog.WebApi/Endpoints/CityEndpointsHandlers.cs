using RealEstateCatalog.Core.Domain.Models;
using RealEstateCatalog.Core.Application.Interfaces;

namespace RealEstateCatalog.WebApi.Endpoints;

internal static class CityEndpointsHandlers
{
    internal static async Task<IResult> GetAllAsync(
        ICityRepository cityRepository,
        CancellationToken cancellationToken = default)
    {
        var response = await cityRepository.GetAllAsync(cancellationToken);
        
        return response is null || !response.Any()
            ? Results.NoContent()
            : Results.Ok(response);
    }

    internal static async Task<IResult> GetByIdAsync(
        int id,
        ICityRepository cityRepository,
        CancellationToken cancellationToken = default)
    {
        var response = await cityRepository.GetByIdAsync(id, cancellationToken);

        return response is null
            ? Results.NoContent()
            : Results.Ok(response);
    }

    internal static async Task<IResult> CreateAsync(
        string cityName,
        ICityRepository cityRepository,
        CancellationToken cancellationToken = default)
    {
        var city = new City { Name = cityName };

        var response = await cityRepository.CreateAsync(city, cancellationToken);

        return response is City cityResult
            ? Results.Created($"api/city/{cityResult.Id}", cityResult)
            : Results.BadRequest();
    }

    internal static async Task<IResult> UpdateAsync(
        City city,
        ICityRepository cityRepository,
        CancellationToken cancellationToken = default)
    {
        var entity = await cityRepository.GetByIdAsync(city.Id, cancellationToken);
        if (entity is null) return Results.NotFound();
        await cityRepository.UpdateAsync(city, cancellationToken);
        return Results.Ok();
    }

    internal static async Task<IResult> DeleteAsync(
        int id,
        ICityRepository cityRepository,
        CancellationToken cancellationToken = default)
    {
        var entity = await cityRepository.GetByIdAsync(id, cancellationToken);
        if (entity is null) return Results.NotFound();

        await cityRepository.DeleteAsync(entity, cancellationToken);
        return Results.NoContent();
    }
}
