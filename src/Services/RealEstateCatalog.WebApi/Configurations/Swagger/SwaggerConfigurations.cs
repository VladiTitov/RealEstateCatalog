namespace RealEstateCatalog.WebApi.Configurations.Swagger;

internal static class SwaggerConfigurations
{
    internal static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        => services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

    internal static IApplicationBuilder UseSwaggerConfiguration(this WebApplication application)
        => application
            .UseSwagger()
            .UseSwaggerUI();
}
