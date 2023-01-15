using System.Net;
using RealEstateCatalog.WebApi.Errors;
using RealEstateCatalog.WebApi.Exceptions;

namespace RealEstateCatalog.WebApi.Endpoints;

internal static class UserEndpointsHandlers
{
    internal static async Task<IResult> LoginAsync(
        LoginRequestDto loginRequestDto,
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        CancellationToken cancellationToken = default)
    {
        var user = await unitOfWork.UserRepository.AuthenticateAsync(loginRequestDto, cancellationToken);
        return user is null
            ? throw new UnauthorizedException("Invalid Username or Password.")
            : Results.Ok(authenticationService.GetLoginRequest(user));
    }

    internal static async Task<IResult> RegisterAsync(
        LoginRequestDto loginRequestDto,
        IUnitOfWork unitOfWork,
        CancellationToken cancellationToken = default)
    {
        if (await unitOfWork.UserRepository.UserAlreadyExistsAsync(loginRequestDto.Username, cancellationToken))
        {
            var apiError = new ApiError((int)HttpStatusCode.BadRequest, "User already exists, please try something else.");
            return Results.BadRequest(apiError);
        }
        unitOfWork.UserRepository.Register(loginRequestDto);
        await unitOfWork.SaveAsync(cancellationToken);
        return Results.Ok();
    }
}
