using RealEstateCatalog.Core.Domain.Dtos;

namespace RealEstateCatalog.Core.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> AuthenticateAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken = default);
}
