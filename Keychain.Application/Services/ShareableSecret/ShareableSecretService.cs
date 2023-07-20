using Keychain_API.Contracts.Responses.ShareableSecret;
using Keychain.Contracts.DTOs.ShareableSecret;

namespace Keychain.Application.Services.ShareableSecret;

public class ShareableSecretService  : IShareableSecretService
{
   

    public RegisterTemporarySecretResponse RegisterTemporarySecret(RegisterTemporarySecretDto registerTemporarySecretDto)
    {
        // this._shareableSecretRepository.Add(new Entities.ShareableSecret(Guid.NewGuid(),"TESTE", new DateTime()));
        return new RegisterTemporarySecretResponse(Guid.NewGuid(),"TESTE", new DateTime());
    }
}