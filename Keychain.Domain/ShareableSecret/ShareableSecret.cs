namespace Keychain.Domain.ShareableSecret;

public class ShareableSecret
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Description { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
    public string Secret { get; set; } = null!;
    public string? Password { get; set; } = null!;
    
    public int ViewCount { get; set; }

}