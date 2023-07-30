namespace Keychain.Contracts.Responses.ShareableSecret;

public record RegisterTemporarySecretResponse(
    Guid Id,
    DateTime ExpirationDate,
    int ViewCount,
    string Secret,
    string? Password
);