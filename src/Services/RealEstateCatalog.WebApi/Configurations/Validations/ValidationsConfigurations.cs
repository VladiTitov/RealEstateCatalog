using FluentValidation;
using RealEstateCatalog.WebApi.Validators;

namespace RealEstateCatalog.WebApi.Configurations.Validations;

internal static class ValidationsConfigurations
{
    internal static IServiceCollection AddValidationsConfiguration(this IServiceCollection services)
        => services
            .AddScoped<IValidator<LoginRequestDto>, LoginRequestDtoValidator>();
}
