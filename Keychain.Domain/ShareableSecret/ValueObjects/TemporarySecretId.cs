using Keychain.Domain.Common.Models.Identities;

namespace Keychain.Domain.Entities.ValueObjects;

public class TemporarySecretId : EntityId<Guid>
{
    public Guid Value { get; }

    private TemporarySecretId(Guid value) : base(value)
    {
    }

    public static TemporarySecretId Create(Guid value)
    {
        return new TemporarySecretId(value);
    }
    
    public static TemporarySecretId CreateUnique()
    {
        return new TemporarySecretId(Guid.NewGuid());
    }
}