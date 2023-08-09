namespace Keychain.Contracts.Responses.ShareableSecret;

public record RegisterTemporarySecretResponse(
    Guid Id,
    DateTime ExpirationDate,
    int ViewCount,
    int MaxViewCount,
    string Secret,
    string? Password
);
