using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Domain.Vault;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Secret?> Detail(Guid id)
    {
        return await _dbContext.FindAsync<Secret>(id);
    }

    public async Task<List<Secret>> FindAllByUser(int id)
    {
        return await _dbContext.Secret.Where(
            secret => secret.UserId == id
        ).ToListAsync();
    }
}
