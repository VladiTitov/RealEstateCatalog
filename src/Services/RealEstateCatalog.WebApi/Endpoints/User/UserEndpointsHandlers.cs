﻿using System.Net;
using FluentValidation;
using RealEstateCatalog.WebApi.Errors;
using RealEstateCatalog.WebApi.Exceptions;

namespace RealEstateCatalog.WebApi.Endpoints.User;

internal static class UserEndpointsHandlers
{
    internal static async Task<IResult> LoginAsync(
        LoginRequestDto loginRequestDto,
        IValidator<LoginRequestDto> validator,
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(loginRequestDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

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
