using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Contracts.Responses.ShareableSecret;
using MediatR;
using ErrorOr;
using Keychain.Application.Common.Interfaces.Helpers;

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
        await Task.CompletedTask;

        var encryptedSecret = _encryptionHelper.Encrypt(command.Secret);
        if(command.Password != null)
        {
            encryptedSecret = _encryptionHelper.Encrypt(encryptedSecret, command.Password);
        }
        var shareableSecret = new Domain.ShareableSecret.ShareableSecret
        {
            Id = Guid.NewGuid(),
            Secret = encryptedSecret,
            ExpirationDate = DateTime.UtcNow,
            MaxViewCount = command.ViewCount,
            CurrentViewCount = 0,
        };
        await _repository.Register(shareableSecret);
        return new RegisterTemporarySecretResponse(shareableSecret.Id, shareableSecret.ExpirationDate, command.ViewCount, command.Secret, command.Password );
    }
}
