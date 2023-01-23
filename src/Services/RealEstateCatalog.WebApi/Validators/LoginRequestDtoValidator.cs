using FluentValidation;

namespace RealEstateCatalog.WebApi.Validators;

internal class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestDtoValidator()
    {
        RuleFor(_ => _.Username)
            .NotNull()
            .NotEmpty();
        RuleFor(_ => _.Password)
            .NotNull()
            .NotEmpty();
    }
}
