using RealEstateCatalog.WebApi.Errors;
using System.Net;

namespace RealEstateCatalog.WebApi.Middlewares;

internal class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
	private readonly ILogger<ErrorHandlerMiddleware> _logger;
	private readonly IHostEnvironment _environment;

	public ErrorHandlerMiddleware(
		RequestDelegate next,
		ILogger<ErrorHandlerMiddleware> logger,
		IHostEnvironment environment)
	{
		_next = next;
		_logger = logger;
		_environment = environment;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception error)
		{
			var httpStatusCode = HttpStatusCode.InternalServerError;
			var message = error.Message;

            switch (error) 
			{
				case UnauthorizedAccessException:
					httpStatusCode = HttpStatusCode.Forbidden;
					message = "You are not authorized";
					break;
			}

            var apiError = _environment.IsDevelopment()
                ? new ApiError((int)httpStatusCode, error.Message, error.StackTrace?.ToString())
                : new ApiError((int)httpStatusCode, message);


            _logger.LogError(error, error.Message);
            var response = context.Response;
            response.ContentType = "application/json";
			response.StatusCode = (int)httpStatusCode;
			await response.WriteAsync(apiError.ToString());
        }
	}
}
