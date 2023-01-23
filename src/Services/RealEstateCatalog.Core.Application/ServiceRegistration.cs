using Microsoft.Extensions.DependencyInjection;
using RealEstateCatalog.Core.Application.Services;

namespace RealEstateCatalog.Core.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        => services
            .AddSingleton<IAuthenticationService, AuthenticationService>();
}
