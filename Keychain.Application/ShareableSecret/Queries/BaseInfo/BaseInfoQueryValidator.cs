using FluentValidation;
using Keychain.Application.ShareableSecret.Commands.Visualize;

namespace Keychain.Application.ShareableSecret.Queries.BaseInfo;

public class BaseQueryValidator: AbstractValidator<VisualizeCommand>
{
    public BaseQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
