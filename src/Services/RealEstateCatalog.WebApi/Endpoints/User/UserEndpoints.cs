namespace RealEstateCatalog.WebApi.Endpoints.User;

internal static class UserEndpoints
{
    internal static WebApplication MapUserEnpoints(this WebApplication app)
    {
        app.MapPost(
            pattern: "api/account/login",
            handler: UserEndpointsHandlers.LoginAsync)
            .WithName("Login");

        app.MapPost(
            pattern: "api/account/register",
            handler: UserEndpointsHandlers.RegisterAsync)
            .WithName("Register");

        return app;
    }
}
