using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Contracts.Responses.ShareableSecret;
using MediatR;
using ErrorOr;
using Keychain.Application.Common.Interfaces.Helpers;
using Keychain.Contracts.Responses.Encryption;

namespace Keychain.Application.ShareableSecret.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterTemporarySecretResponse>>
{
    private readonly IShareableSecretRepository _repository;
    private readonly IEncryptionHelper _encryptionHelper;

    public RegisterCommandHandler(IShareableSecretRepository repository, IEncryptionHelper encryptionHelper)
    {
        _repository = repository;
        _encryptionHelper = encryptionHelper;
    }

    public async Task<ErrorOr<RegisterTemporarySecretResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var encryptedSecret = command.Password != null ? _encryptionHelper.Encrypt(command.Secret, command.Password) : _encryptionHelper.Encrypt(command.Secret);
        var shareableSecret = new Domain.ShareableSecret.ShareableSecret
        {
            Id = Guid.NewGuid(),
            Secret = encryptedSecret.EncryptedValue,
            ExpirationDate = DateTime.UtcNow,
            MaxViewCount = command.ViewCount,
            CurrentViewCount = 0,
            Iv = encryptedSecret.Iv,
            HasPassword = command.Password != null,
        };
        await _repository.Register(shareableSecret);
        return new RegisterTemporarySecretResponse(shareableSecret.Id, shareableSecret.ExpirationDate, command.ViewCount, command.Secret, command.Password );
    }
}
