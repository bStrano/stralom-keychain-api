namespace Keychain.Contracts.Responses.ShareableSecret;

public record BaseInfoSecretResponse
(
    Guid Id,
    DateTime ExpirationDate,
    int MaxViewCount,
    int RemainingViews,
    bool HasPassword
);
