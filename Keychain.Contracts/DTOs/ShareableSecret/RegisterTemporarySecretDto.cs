
namespace Keychain.Contracts.DTOs.ShareableSecret;

public record RegisterTemporarySecretDto(
    string Secret, int MaxViewCount, DateTime? ExpirationDate, string? Password
);
