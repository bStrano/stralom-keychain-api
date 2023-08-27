using Keychain.Contracts.Responses.ShareableSecret;
using Keychain.Domain.Vault;
using Mapster;

namespace Keychain_API.Common.Mapping;

public class SecretMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterTemporarySecretResponse, Secret>();
    }
}
