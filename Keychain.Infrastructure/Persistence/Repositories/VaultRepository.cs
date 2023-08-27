using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Domain.Vault;

namespace Keychain.Infrastructure.Persistence.Repositories;

public class VaultRepository : IVaultRepository
{

    private readonly KeychainDbContext _dbContext;

    public VaultRepository(KeychainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Register(Secret secret)
    {
       await _dbContext.AddAsync(secret);
       await _dbContext.SaveChangesAsync();
    }
}
