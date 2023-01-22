using System.Security.Claims;

namespace RealEstateCatalog.Core.Application.Interfaces;

public interface IAuthenticationService
{
    LoginResponseDto GetLoginRequest(User user);
    int GetUserId(ClaimsPrincipal user);
}
