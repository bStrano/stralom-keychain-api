using FluentValidation;

namespace Keychain.Application.ShareableSecret.Queries.Detail;

public class DetailQueryValidator: AbstractValidator<DetailQuery>
{
    public DetailQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
