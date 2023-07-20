
namespace Keychain.Contracts.DTOs.ShareableSecret;

public record RegisterTemporarySecretDto(
    string Secret,
    string Password
    // LifeTimeSecretEnum LifeTime
);