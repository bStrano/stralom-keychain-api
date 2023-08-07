namespace Keychain.Domain.ShareableSecret;

public sealed class ShareableSecret
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string? Description { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
    public string Secret { get; set; } = null!;
    public int MaxViewCount { get; set; }

    public int CurrentViewCount { get; set; } = 0;

    public bool HasPassword { get; set; } = false;

    public byte[] Iv { get; set; }

    public DateTime? BurnedAt { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; } = null;

    public void Visualize()
    {
        CurrentViewCount++;
        if (CurrentViewCount >= MaxViewCount)
        {
            Burn();
        }
    }

    public void Burn()
    {
        Secret = "🔥 Burned 🔥";
        BurnedAt = DateTime.UtcNow;
    }

    public int RemainingViews()
    {
        return MaxViewCount - CurrentViewCount;
    }

    public ShareableSecret()
    {
    }
}
