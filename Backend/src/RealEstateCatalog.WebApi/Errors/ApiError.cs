using System.Text.Json;

namespace RealEstateCatalog.WebApi.Errors;

#nullable disable
public class ApiError
{
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public string ErrorDetails { get; set; }

    public ApiError()
    { }

    public ApiError(int errorCode, string errorMessage, string errorDetails = null)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
        ErrorDetails = errorDetails;
    }

    public override string ToString()
    {
        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        return JsonSerializer.Serialize(this, options);
    }
}
