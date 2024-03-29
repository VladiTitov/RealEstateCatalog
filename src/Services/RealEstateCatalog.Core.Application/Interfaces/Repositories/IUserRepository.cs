﻿namespace RealEstateCatalog.Core.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> AuthenticateAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken = default);
    void Register(LoginRequestDto loginRequestDto);
    Task<bool> UserAlreadyExistsAsync(string userName, CancellationToken cancellationToken = default);
}
