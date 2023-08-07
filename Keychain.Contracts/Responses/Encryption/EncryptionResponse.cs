namespace Keychain.Contracts.Responses.Encryption;

public record EncryptionResponse
(
    string EncryptedValue,
    byte[] Iv
);
