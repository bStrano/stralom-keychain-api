namespace Keychain.Contracts.Responses.ShareableSecret;

public record DetailSecretResponse
(
    Guid Id,
    DateTime ExpirationDate,
    int MaxViewCount,
    string Secret
);
