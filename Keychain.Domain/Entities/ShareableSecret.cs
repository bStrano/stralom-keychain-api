namespace Keychain.Domain.Entities;

public class ShareableSecret
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Link { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Secret { get; set; }
    public string Password { get; set; }
    
    public ShareableSecret(string link, DateTime expirationDate, string secret, string password)
    {
        Link = link;
        ExpirationDate = expirationDate;
        Secret = secret;
        Password = password;
    }
    
}