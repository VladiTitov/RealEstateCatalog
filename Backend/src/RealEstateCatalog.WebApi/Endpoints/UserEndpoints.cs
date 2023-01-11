using AutoMapper;
using RealEstateCatalog.Core.Application.Interfaces;
using RealEstateCatalog.Core.Domain.Dtos;
using System.Security.Authentication;

namespace RealEstateCatalog.WebApi.Endpoints;

internal static class UserEndpoints
{
    internal static WebApplication MapUserEnpoints(this WebApplication app)
    {
        app.MapPost(
            pattern: "api/account/login",
            handler: LoginAsync)
            .WithName("Login");

        return app;
    }

    private static async Task<IResult> LoginAsync(
        LoginRequestDto loginRequestDto, 
        IMapper mapper,
        IUnitOfWork unitOfWork,
        CancellationToken cancellationToken = default)
    {
        var user = await unitOfWork.UserRepository.AuthenticateAsync(loginRequestDto, cancellationToken);
        return user is null
            ? Results.Unauthorized()
            : Results.Ok(mapper.Map<LoginResponseDto>(user));
    }
}
