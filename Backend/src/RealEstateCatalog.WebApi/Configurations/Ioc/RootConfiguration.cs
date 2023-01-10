﻿using RealEstateCatalog.Infrastructure.Persistence;
using RealEstateCatalog.WebApi.Configurations.Authentification;
using RealEstateCatalog.WebApi.Configurations.Cors;
using RealEstateCatalog.WebApi.Configurations.Middlewares;
using RealEstateCatalog.WebApi.Configurations.Swagger;
using System.Reflection;

namespace RealEstateCatalog.WebApi.Configurations.Ioc;

internal static class RootConfiguration
{
    internal static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddPersistenceLayer(configuration)
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddSwaggerConfiguration()
            .AddCorsConfiguration()
            .AddCustomAuthentification()
            .AddAuthorization();
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
        application.UseAuthentication();
        application.UseAuthorization();
        application.MapCityEnpoints();
        application.MapUserEnpoints();
        application.UseErrorHandlingMiddleware();
        return application;
    }
}