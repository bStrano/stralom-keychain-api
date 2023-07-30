
namespace Keychain.Contracts.DTOs.ShareableSecret;

public record RegisterTemporarySecretDto(
    string Secret, int ViewCount, DateTime? ExpirationDate, string? Password
);