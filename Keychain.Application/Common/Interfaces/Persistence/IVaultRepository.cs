using Keychain.Domain.Vault;

namespace Keychain.Application.Common.Interfaces.Persistence;

public interface IVaultRepository
{
    Task Register(Secret secret);
    Task<Secret?> Detail(Guid id);
    Task<List<Secret>> FindAllByUser(int userId);
}
