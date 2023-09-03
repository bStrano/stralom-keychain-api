using Keychain.Domain.Vault;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Keychain.Infrastructure.Persistence.Configurations;

public class SecretConfiguration : IEntityTypeConfiguration<Secret>
{
    public void Configure(EntityTypeBuilder<Secret> builder)
    {
        ConfigureSecretTable(builder);
    }

    private void ConfigureSecretTable(EntityTypeBuilder<Secret> builder)
    {
        builder.ToTable("Secrets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
        builder.Property(x => x.UserName).HasMaxLength(10000).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(10000).IsRequired();
        builder.Property(x => x.Iv).IsRequired();
        builder.Property(x => x.LastPasswordChange).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
    }
}
