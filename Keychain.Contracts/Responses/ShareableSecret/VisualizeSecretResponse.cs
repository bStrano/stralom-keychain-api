namespace Keychain.Contracts.Responses.ShareableSecret;

public record VisualizeSecretResponse
(
    Guid Id,
    DateTime ExpirationDate,
    int MaxViewCount,
    int RemainingViews,
    string Secret,
    bool HasPassword
);
