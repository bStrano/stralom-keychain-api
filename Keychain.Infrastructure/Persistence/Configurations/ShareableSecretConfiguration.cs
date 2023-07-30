using Keychain.Domain.ShareableSecret;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Keychain.Infrastructure.Persistence.Configurations;

public class ShareableSecretConfiguration : IEntityTypeConfiguration<ShareableSecret>
{
    public void Configure(EntityTypeBuilder<ShareableSecret> builder)
    {
        ConfigureShareableSecretTable(builder);
    }

    private void ConfigureShareableSecretTable(EntityTypeBuilder<ShareableSecret> builder)
    {
        builder.ToTable("ShareableSecrets");
        builder.HasKey(x => x.Id);  
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Secret).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.ExpirationDate).IsRequired();
    }
}