using Keychain.Application.Common.Interfaces.Helpers;
using Keychain.Infrastructure.Constants;
using Microsoft.Extensions.Options;

namespace Keychain.Infrastructure.Helpers;

using System;
using System.Security.Cryptography;
using System.Text;

public class EncryptionHelper : IEncryptionHelper
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    public EncryptionHelper(IOptions<EncryptionSettings> encryptionOptions)
    {
        var encryptionSettings = encryptionOptions.Value;
        _key = Encoding.UTF8.GetBytes(encryptionSettings.KEY);
        _iv = Encoding.UTF8.GetBytes(encryptionSettings.IV);
    }


    public string Encrypt(string plainText, string? customKey = null)
    {
        byte[] encrypted;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = customKey is not null ? DeriveAes256Key(customKey) : _key;
            aesAlg.IV = _iv;
            aesAlg.Mode = CipherMode.CBC;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        return Convert.ToBase64String(encrypted);
    }

    public string Decrypt(string cipherText)
    {
        var cipherTextBytes = Convert.FromBase64String(cipherText);
        string decryptedText;
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = _key;
            aesAlg.IV = _iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        decryptedText = srDecrypt.ReadToEnd();
                    }
                }
            }
        }
        return decryptedText;
    }

    byte[] DeriveAes256Key(string password)
    {
        byte[] salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        int iterations = 10000;

        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
        {
            return pbkdf2.GetBytes(32); // 256-bit key (32 bytes)
        }
    }

}
