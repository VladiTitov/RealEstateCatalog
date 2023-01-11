namespace RealEstateCatalog.Core.Application.Interfaces;

public interface IAuthenticationService
{
    LoginResponseDto GetLoginRequest(User user);
}
