using Microsoft.EntityFrameworkCore;

namespace Keychain.Infrastructure.Persistence;

public class KeychainDbContext : DbContext
{
    public KeychainDbContext(DbContextOptions options) : base(options)
    {
    }
}