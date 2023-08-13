using FluentValidation;

namespace Keychain.Application.ShareableSecret.Commands.Visualize;

public class VisualizeCommandValidator: AbstractValidator<VisualizeCommand>
{
    public VisualizeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
