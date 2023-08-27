using FluentValidation;

namespace Keychain.Application.Vault.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}
