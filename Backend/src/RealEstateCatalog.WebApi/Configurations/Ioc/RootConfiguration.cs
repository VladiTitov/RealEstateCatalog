using RealEstateCatalog.Infrastructure.Persistence;
using RealEstateCatalog.WebApi.Configurations.Cors;
using RealEstateCatalog.WebApi.Configurations.Swagger;

namespace RealEstateCatalog.WebApi.Configurations.Ioc;

internal static class RootConfiguration
{
    internal static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddPersistenceLayer(configuration)
            .AddSwaggerConfiguration()
            .AddCorsConfiguration();
    }

    internal static WebApplication ConfigureWebApplication(this WebApplication application)
    {
        if (application.Environment.IsDevelopment())
        {
            application.UseDeveloperExceptionPage();
            application.UseSwaggerConfiguration();
        }
        application.UseCorsConfiguration();
        application.UseHttpsRedirection();
        application.MapCityEnpoints();
        return application;
    }
}
