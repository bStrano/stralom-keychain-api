using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Contracts.Responses.ShareableSecret;
using ErrorOr;
using Keychain.Application.Common.Interfaces.Helpers;
using Keychain.Domain.Common.DomainErrors;
using MediatR;

namespace Keychain.Application.ShareableSecret.Queries.Detail;

public class DetailQueryHandler : IRequestHandler<DetailQuery, ErrorOr<DetailSecretResponse>>
{
    private readonly IShareableSecretRepository _repository;
    private readonly IEncryptionHelper _encryptionHelper;

    public DetailQueryHandler(IShareableSecretRepository repository, IEncryptionHelper encryptionHelper)
    {
        _repository = repository;
        _encryptionHelper = encryptionHelper;
    }

    public async Task<ErrorOr<DetailSecretResponse>> Handle(DetailQuery command, CancellationToken cancellationToken)
    {
        var response = await this._repository.Detail(command.Id);


        if (response == null)
        {
            return Errors.ShareableSecret.NotFound(command.Id);
        }

        if (response.HasPassword && command.Password == null)
        {
            return Errors.ShareableSecret.PasswordRequired(command.Id);
        }

        string decryptedSecret;
        try
        {
            if (response.HasPassword && command.Password != null)
            {
                decryptedSecret =
                    _encryptionHelper.Decrypt(_encryptionHelper.Decrypt(response.Secret, command.Password));
            }
            else
            {
                decryptedSecret = _encryptionHelper.Decrypt(response.Secret);
            }
        }
        catch (Exception)
        {
            return Errors.ShareableSecret.PasswordNotMatch(command.Id);
        }


        response.Visualize();
        await _repository.Update(response);
        return new DetailSecretResponse(response.Id, response.ExpirationDate, response.MaxViewCount,
            response.RemainingViews(), decryptedSecret);
    }
}
