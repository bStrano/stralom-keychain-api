using Keychain.Domain.Common.Models;
using Keychain.Domain.ShareableSecret;
using Keychain.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Keychain.Infrastructure.Persistence;

public class KeychainDbContext : DbContext
{
    // private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public KeychainDbContext(DbContextOptions options) : base(options)
    {
        // _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<ShareableSecret> ShareableSecrets { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(KeychainDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
    //     base.OnConfiguring(optionsBuilder);
    // }
}
