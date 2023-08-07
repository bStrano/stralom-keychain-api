namespace Keychain.Contracts.Responses.ShareableSecret;

public record DetailSecretResponse
(
    Guid Id,
    DateTime ExpirationDate,
    int MaxViewCount,
    int RemainingViews,
    string Secret
);
