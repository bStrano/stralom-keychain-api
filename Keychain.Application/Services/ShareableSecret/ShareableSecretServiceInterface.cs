using Keychain_API.Contracts.Responses.ShareableSecret;
using Keychain.Contracts.DTOs.ShareableSecret;

namespace Keychain.Application.Services.ShareableSecret;


public interface IShareableSecretService
{
    RegisterTemporarySecretResponse RegisterTemporarySecret(RegisterTemporarySecretDto registerTemporarySecretDto);
}