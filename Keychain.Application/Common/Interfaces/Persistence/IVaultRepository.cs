using Keychain.Domain.Vault;

namespace Keychain.Application.Common.Interfaces.Persistence;

public interface IVaultRepository
{
    Task Register(Secret secret);
}
