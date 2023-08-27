namespace Keychain.Contracts.Responses.Vault;

public record RegisterSecretResponse(Guid id,
    string title,
    string description,
    string userName,
    string password,
    DateTime lastPasswordChange,
    DateTime createdAt,
    DateTime? updatedAt,
    int userId
    );
