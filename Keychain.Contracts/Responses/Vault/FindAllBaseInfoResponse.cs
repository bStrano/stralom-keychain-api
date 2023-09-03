namespace Keychain.Contracts.Responses.Vault;

public record FindAllBaseInfoResponse(
    Guid Id,
    string Title,
    string Description,
    string UserName,
    DateTime LastPasswordChange,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
