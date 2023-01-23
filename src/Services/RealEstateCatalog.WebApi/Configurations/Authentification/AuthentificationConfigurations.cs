using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RealEstateCatalog.WebApi.Configurations.Authentification;

public static class AuthentificationConfigurations
{
    public static IServiceCollection AddCustomAuthentification(this IServiceCollection services, IConfiguration configuration)
    {
        var sectionKey = "AuthenticationPrivateKey";

        var secretKey = configuration.GetSection(sectionKey).Value ??
            throw new ArgumentNullException(sectionKey);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = key
                };
            });

        return services;
    }

    public static IApplicationBuilder UseCustomAuthorization(this WebApplication application)
        => application
            .UseAuthorization();
}
