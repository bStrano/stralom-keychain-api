namespace Keychain.Domain.ShareableSecret.ValueObjects;

public class TemporarySecret : ValueObject
{
    public string Secret { get; private set; }
    public string Password { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public int ViewCount { get; private set; }

    private TemporarySecret(string secret, string password, DateTime lifetime, int viewCount)
    {
        this.Secret = secret;
        this.Password = password;
        this.ExpirationDate = lifetime;
        this.ViewCount = viewCount;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Secret;
        yield return Password;
        yield return ExpirationDate;
        yield return ViewCount;
    }
    
    #pragma warning disable CS8618
    private TemporarySecret(){}
    #pragma warning restore CS8618
}