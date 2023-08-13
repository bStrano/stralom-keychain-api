using ErrorOr;
using Keychain.Application.Common.Interfaces.Helpers;
using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Contracts.Responses.ShareableSecret;
using Keychain.Domain.Common.DomainErrors;
using MediatR;

namespace Keychain.Application.ShareableSecret.Commands.Visualize;

public class VisualizeCommandHandler : IRequestHandler<VisualizeCommand, ErrorOr<VisualizeSecretResponse>>
{
    private readonly IShareableSecretRepository _repository;
    private readonly IEncryptionHelper _encryptionHelper;

    public VisualizeCommandHandler(IShareableSecretRepository repository, IEncryptionHelper encryptionHelper)
    {
        _repository = repository;
        _encryptionHelper = encryptionHelper;
    }

    public async Task<ErrorOr<VisualizeSecretResponse>> Handle(VisualizeCommand command, CancellationToken cancellationToken)
    {
        var response = await _repository.Detail(command.Id);


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
                    _encryptionHelper.Decrypt(response.Secret, response.Iv, command.Password);
            }
            else
            {
                decryptedSecret = _encryptionHelper.Decrypt(response.Secret, response.Iv);
            }
        }
        catch (Exception)
        {
            return Errors.ShareableSecret.PasswordNotMatch(command.Id);
        }


        response.Visualize();
        await _repository.Update(response);
        return new VisualizeSecretResponse(response.Id, response.ExpirationDate, response.MaxViewCount,
            response.RemainingViews(), decryptedSecret, response.HasPassword);
    }


}
