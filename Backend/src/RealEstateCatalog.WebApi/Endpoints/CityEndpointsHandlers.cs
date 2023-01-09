using RealEstateCatalog.Core.Domain.Models;
using RealEstateCatalog.Core.Application.Interfaces;
using RealEstateCatalog.Core.Domain.Dtos;

namespace RealEstateCatalog.WebApi.Endpoints;

internal static class CityEndpointsHandlers
{
    internal static async Task<IResult> GetAllAsync(
        ICityRepository cityRepository,
        CancellationToken cancellationToken = default)
    {
        var response = await cityRepository.GetAllAsync(cancellationToken);
        if (response is null || !response.Any()) return Results.NoContent();
        var resultData = new List<CityDto>();
        foreach (var cityDto in response) 
        {
            resultData.Add(new CityDto
            {
                Id = cityDto.Id,
                Name = cityDto.Name
            });
        }

        return Results.Ok(resultData);
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
        var city = new City { 
            Name = cityName,
            LastUpdatedBy = 1,
            LastUpdatedOn = DateTime.Now
        };

        var response = await cityRepository.CreateAsync(city, cancellationToken);
        if (response is null) return Results.BadRequest();
        var resultData = new CityDto 
        { 
            Id = response.Id, 
            Name = response.Name 
        };
        return Results.Created($"api/city/{resultData.Id}", resultData);
    }

    internal static async Task<IResult> UpdateAsync(
        CityDto city,
        ICityRepository cityRepository,
        CancellationToken cancellationToken = default)
    {
        var entity = await cityRepository.GetByIdAsync(city.Id, cancellationToken);
        if (entity is null) return Results.NotFound();
        await cityRepository.UpdateAsync(entity, cancellationToken);
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
