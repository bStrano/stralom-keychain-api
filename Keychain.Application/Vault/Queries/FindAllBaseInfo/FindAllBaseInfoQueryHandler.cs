using Keychain.Contracts.Responses.Vault;
using MediatR;
using ErrorOr;
using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Domain.Common.DomainErrors;

namespace Keychain.Application.Vault.Queries.FindAllBaseInfo;

public class FindAllBaseInfoQueryHandler : IRequestHandler<FindAllBaseInfoQuery, ErrorOr<List<FindAllBaseInfoResponse>>>
{
    private readonly IVaultRepository _repository;

    public FindAllBaseInfoQueryHandler(IVaultRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<List<FindAllBaseInfoResponse>>> Handle(FindAllBaseInfoQuery request, CancellationToken cancellationToken)
    {

        var response = await _repository.FindAllByUser(request.UserId);

        return response.Select(secret => new FindAllBaseInfoResponse(secret.Id, secret.Title, secret.Description, secret.UserName, secret.LastPasswordChange, secret.CreatedAt, secret.UpdatedAt)).ToList();
    }
}
