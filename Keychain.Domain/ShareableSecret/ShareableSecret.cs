namespace Keychain.Domain.ShareableSecret;

public sealed class ShareableSecret
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string? Description { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
    public string Secret { get; set; } = null!;
    public int MaxViewCount { get; set; }

    public int CurrentViewCount { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; } = null;

    public ShareableSecret()
    {
    }
}
