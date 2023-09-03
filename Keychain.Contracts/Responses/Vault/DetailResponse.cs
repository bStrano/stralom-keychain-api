namespace Keychain.Contracts.Responses.Vault;

public record DetailResponse(
    Guid Id,
    string Title,
    string Description,
    string UserName,
    string Password,
    DateTime LastPasswordChange,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
