using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Domain.ShareableSecret;
using Microsoft.EntityFrameworkCore;

namespace Keychain.Infrastructure.Persistence.Repositories;

public class ShareableSecretRepository : IShareableSecretRepository
{
    private readonly KeychainDbContext _dbContext;

    public ShareableSecretRepository(KeychainDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<ShareableSecret?> Detail(Guid id)
    {
        return await _dbContext.ShareableSecrets.FirstOrDefaultAsync( u => u.Id == id);
    }

    public async Task Register(ShareableSecret shareableSecret)
    {
        await _dbContext.AddAsync(shareableSecret);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(ShareableSecret shareableSecret)
    {
        _dbContext.Update(shareableSecret);
        await _dbContext.SaveChangesAsync();
    }
}
