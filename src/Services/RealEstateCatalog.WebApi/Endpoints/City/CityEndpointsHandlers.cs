using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace RealEstateCatalog.WebApi.Endpoints.City;

internal static class CityEndpointsHandlers
{
    internal static async Task<IResult> GetAllAsync(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        CancellationToken cancellationToken = default)
    {
        var response = await unitOfWork.CityRepository.GetAllAsync(cancellationToken);

        return response is null || !response.Any()
            ? Results.NoContent()
            : Results.Ok(mapper.Map<IReadOnlyList<KeyValuePairDto>>(response));
    }

    internal static async Task<IResult> GetByIdAsync(
        int id,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        CancellationToken cancellationToken = default)
    {
        var response = await unitOfWork.CityRepository.GetByIdAsync(id, cancellationToken);

        return response is null
            ? Results.NoContent()
            : Results.Ok(mapper.Map<CityDto>(response));
    }

    internal static async Task<IResult> CreateAsync(
        string cityName,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        CancellationToken cancellationToken = default)
    {
        var response = unitOfWork.CityRepository.Create(cityName);
        await unitOfWork.SaveAsync(cancellationToken);
        return response is null
            ? Results.BadRequest()
            : Results.Created($"api/city/{response.Id}", mapper.Map<CityDto>(response));
    }

    internal static async Task<IResult> UpdateAsync(
        CityDto city,
        IUnitOfWork unitOfWork,
        CancellationToken cancellationToken = default)
    {
        var entity = await unitOfWork.CityRepository.GetByIdAsync(city.Id, cancellationToken);
        if (entity is null) return Results.NotFound();
        unitOfWork.CityRepository.Update(entity);
        await unitOfWork.SaveAsync(cancellationToken);
        return Results.Ok();
    }

    internal static async Task<IResult> DeleteAsync(
        int id,
        IUnitOfWork unitOfWork,
        CancellationToken cancellationToken = default)
    {
        var entity = await unitOfWork.CityRepository.GetByIdAsync(id, cancellationToken);
        if (entity is null) return Results.NotFound();

        unitOfWork.CityRepository.Delete(entity);
        await unitOfWork.SaveAsync(cancellationToken);
        return Results.NoContent();
    }
}
