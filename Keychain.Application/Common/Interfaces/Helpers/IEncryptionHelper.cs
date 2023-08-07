namespace Keychain.Application.Common.Interfaces.Helpers;

public interface IEncryptionHelper
{
    public string Encrypt(string plainText, string? customKey = null);
    public string Decrypt(string cipherText, string? customKey = null);
}
