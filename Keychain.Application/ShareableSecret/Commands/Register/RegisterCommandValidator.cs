using FluentValidation;

namespace Keychain.Application.ShareableSecret.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Secret).NotEmpty();
        RuleFor(x => x.ViewCount).GreaterThan(0);
        RuleFor(x => x.ExpirationDate).GreaterThan(DateTime.Now);
        RuleFor(x => x.Password).NotEmpty();
    }
}