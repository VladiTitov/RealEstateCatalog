namespace RealEstateCatalog.WebApi.Configurations.Cors;

internal static class CorsConfigurations
{
    internal static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        => services
            .AddCors();

    internal static IApplicationBuilder UseCorsConfiguration(this WebApplication application)
        => application
            .UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
}
