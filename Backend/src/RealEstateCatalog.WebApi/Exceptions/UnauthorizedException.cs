namespace RealEstateCatalog.WebApi.Exceptions;

public class UnauthorizedException : Exception
{
	public UnauthorizedException(string message) : base(message)
	{
	}
}
