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
            ? Results.Unauthorized()
            : Results.Ok(authenticationService.GetLoginRequest(user));
    }

    internal static async Task<IResult> RegisterAsync(
        LoginRequestDto loginRequestDto,
        IUnitOfWork unitOfWork,
        CancellationToken cancellationToken = default)
    {
        if (await unitOfWork.UserRepository.UserAlreadyExistsAsync(loginRequestDto.Username, cancellationToken))
            return Results.BadRequest("User already exists, please try something else.");

        unitOfWork.UserRepository.Register(loginRequestDto);
        await unitOfWork.SaveAsync(cancellationToken);
        return Results.Ok();
    }
}
