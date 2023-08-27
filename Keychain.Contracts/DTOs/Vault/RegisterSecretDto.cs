namespace Keychain.Contracts.DTOs.Vault;

public record RegisterSecretDto(
    string UserName,
    string Password,
    string Title,
    string Subtitle
);
