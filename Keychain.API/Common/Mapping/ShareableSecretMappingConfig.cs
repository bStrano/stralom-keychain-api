using Keychain.Application.ShareableSecret.Commands.Register;
using Keychain.Application.ShareableSecret.Commands.Visualize;
using Keychain.Contracts.Responses.ShareableSecret;
using Mapster;

namespace Keychain_API.Common.Mapping;

public class ShareableSecretMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterTemporarySecretResponse,RegisterCommand>();
        config.NewConfig<string, VisualizeCommand>();
    }
}
