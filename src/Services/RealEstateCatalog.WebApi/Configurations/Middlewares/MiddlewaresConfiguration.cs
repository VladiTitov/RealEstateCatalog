using RealEstateCatalog.WebApi.Middlewares;

namespace RealEstateCatalog.WebApi.Configurations.Middlewares;

internal static class MiddlewaresConfiguration
{
    internal static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
       => app.UseMiddleware<ErrorHandlerMiddleware>();
}
