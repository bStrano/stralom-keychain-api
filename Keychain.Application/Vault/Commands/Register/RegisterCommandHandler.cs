using ErrorOr;
using Keychain.Application.Common.Interfaces.Helpers;
using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Contracts.Responses.Vault;
using Keychain.Domain.Vault;
using MapsterMapper;
using MediatR;

namespace Keychain.Application.Vault.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterSecretResponse>>
{
    private readonly IVaultRepository _vaultRepository;
    private readonly IEncryptionHelper _encryptionHelper;
    private readonly IMapper _mapper;


    public RegisterCommandHandler(IVaultRepository vaultRepository, IMapper mapper, IEncryptionHelper encryptionHelper)
    {
        _vaultRepository = vaultRepository;
        _mapper = mapper;
        _encryptionHelper = encryptionHelper;
    }

    public async Task<ErrorOr<RegisterSecretResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var encryptedPassword =  _encryptionHelper.Encrypt(command.Password);

        var secret = Secret.Create(
            command.Title,
            command.Subtitle,
            command.UserName,
            encryptedPassword.EncryptedValue,
            encryptedPassword.Iv,
            DateTime.UtcNow,
            DateTime.UtcNow,
            null,
            command.UserId
        );

        await this._vaultRepository.Register(secret);

        return _mapper.Map<RegisterSecretResponse>(secret);

    }
}
