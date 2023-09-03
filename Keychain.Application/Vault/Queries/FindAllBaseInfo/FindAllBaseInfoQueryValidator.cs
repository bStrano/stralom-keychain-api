using FluentValidation;

namespace Keychain.Application.Vault.Queries.FindAllBaseInfo;

public class FindAllBaseInfoQueryValidator: AbstractValidator<FindAllBaseInfoQuery>
{
    public FindAllBaseInfoQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}
