using ErrorOr;
using Keychain.Application.Common.Interfaces.Helpers;
using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Contracts.Responses.ShareableSecret;
using Keychain.Domain.Common.DomainErrors;
using MediatR;

namespace Keychain.Application.ShareableSecret.Queries.BaseInfo;

public class BaseInfoHandler : IRequestHandler<BaseInfoQuery, ErrorOr<BaseInfoSecretResponse>>
{
    private readonly IShareableSecretRepository _repository;
    private readonly IEncryptionHelper _encryptionHelper;

    public BaseInfoHandler(IShareableSecretRepository repository, IEncryptionHelper encryptionHelper)
    {
        _repository = repository;
        _encryptionHelper = encryptionHelper;
    }

    public async Task<ErrorOr<BaseInfoSecretResponse>> Handle(BaseInfoQuery query, CancellationToken cancellationToken)
    {
        var response = await _repository.Detail(query.Id);


        if (response == null)
        {
            return Errors.ShareableSecret.NotFound(query.Id);
        }


        return new BaseInfoSecretResponse(response.Id, response.ExpirationDate, response.MaxViewCount,
            response.RemainingViews(), response.HasPassword);
    }


}
