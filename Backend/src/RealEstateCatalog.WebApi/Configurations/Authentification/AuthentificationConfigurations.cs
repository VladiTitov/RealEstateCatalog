using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RealEstateCatalog.WebApi.Configurations.Authentification;

public static class AuthentificationConfigurations
{
    public static IServiceCollection AddCustomAuthentification(this IServiceCollection services)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

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
