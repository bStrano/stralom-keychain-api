namespace Keychain.Domain.Vault;

public class Secret
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public Byte[] Iv { get; private set; }
    public DateTime LastPasswordChange { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int UserId { get; private set; }

    private Secret(
        Guid id,
        string title,
        string description,
        string userName,
        string password,
        Byte[] iv,
        DateTime lastPasswordChange,
        DateTime createdAt,
        DateTime? updatedAt,
        int userId
        )
    {
        Id = id;
        Title = title;
        Description = description;
        UserName = userName;
        Password = password;
        LastPasswordChange = lastPasswordChange;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        UserId = userId;
        Iv = iv;
    }

    public static Secret Create(
        string Title,
        string Description,
        string UserName,
        string Password,
        Byte[] Iv,
        DateTime LastPasswordChange,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int UserId
        )
    {
        return new Secret(
            Guid.NewGuid(),
            Title,
            Description,
            UserName,
            Password,
            Iv,
            LastPasswordChange,
            CreatedAt,
            UpdatedAt,
            UserId
            );
    }
}
