using Keychain.Contracts.Responses.Encryption;

namespace Keychain.Application.Common.Interfaces.Helpers;

public interface IEncryptionHelper
{
    public EncryptionResponse Encrypt(string plainText, string? customKey = null);
    public string Decrypt(string cipherText, byte[] iv, string? customKey = null);
}
