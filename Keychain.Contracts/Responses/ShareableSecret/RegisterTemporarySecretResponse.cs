namespace Keychain_API.Contracts.Responses.ShareableSecret;

public record RegisterTemporarySecretResponse(
    Guid Id,
    string Link,
    DateTime ExpirationDate
);