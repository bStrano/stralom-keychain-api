using FluentValidation;

namespace Keychain.Application.Vault.Queries.Detail;

public class DetailQueryValidator: AbstractValidator<DetailQuery>
{
    public DetailQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}
