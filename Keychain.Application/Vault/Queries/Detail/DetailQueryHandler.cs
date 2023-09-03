using Keychain.Contracts.Responses.Vault;
using MediatR;
using ErrorOr;
using Keychain.Application.Common.Interfaces.Helpers;
using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Domain.Common.DomainErrors;

namespace Keychain.Application.Vault.Queries.Detail;

public class DetailQueryHandler : IRequestHandler<DetailQuery, ErrorOr<DetailResponse>>
{
    private readonly IVaultRepository _repository;
    private readonly IEncryptionHelper _encryptionHelper;

    public DetailQueryHandler(IVaultRepository repository, IEncryptionHelper encryptionHelper)
    {
        _repository = repository;
        _encryptionHelper = encryptionHelper;
    }


    public async Task<ErrorOr<DetailResponse>> Handle(DetailQuery query, CancellationToken cancellationToken)
    {
        var response = await _repository.Detail(query.Id);

        if (response == null || response.UserId != query.UserId)
        {
            return Errors.Vault.NotFound(query.Id);
        }

        var passwordDecrypted = _encryptionHelper.Decrypt(response.Password, response.Iv);
        return new DetailResponse(
            response.Id,
            response.Title,
            response.Description,
            response.UserName,
            passwordDecrypted,
            response.LastPasswordChange,
            response.CreatedAt,
            response.UpdatedAt
        );
    }
}
