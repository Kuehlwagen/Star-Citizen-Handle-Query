using System.Security.Cryptography;
using System.Text;

namespace SCHQ_Server.Classes;
public static class Encryption {

  private static readonly byte[] _saltBytes = [6, 9, 4, 2, 0, 6, 6, 6];
  private static readonly string _password = Encoding.UTF8.GetString([83, 67, 72, 81, 95, 83, 101, 114, 118, 101, 114]);

  private static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes) {
    byte[]? encryptedBytes = null;
    using (MemoryStream ms = new()) {
      using Aes aes = Aes.Create();
      aes.KeySize = 256;
      aes.BlockSize = 128;
      var key = new Rfc2898DeriveBytes(passwordBytes, _saltBytes, 1000, HashAlgorithmName.SHA256);
      aes.Key = key.GetBytes(aes.KeySize / 8);
      aes.IV = key.GetBytes(aes.BlockSize / 8);
      aes.Mode = CipherMode.CBC;
      using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write)) {
        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
        cs.Close();
      }
      encryptedBytes = ms.ToArray();
    }
    return encryptedBytes;
  }

  public static string EncryptText(string? input) {
    return EncryptText(input, _password);
  }

  public static string EncryptText(string? input, string? password) {
    byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input ?? string.Empty);
    byte[] passwordBytes = Encoding.UTF8.GetBytes(password ?? _password);
    passwordBytes = SHA256.HashData(passwordBytes);
    byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);
    string result = Convert.ToBase64String(bytesEncrypted);
    return result;
  }

  private static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes) {
    byte[]? decryptedBytes = null;
    using (MemoryStream ms = new()) {
      using Aes aes = Aes.Create();
      aes.KeySize = 256;
      aes.BlockSize = 128;
      var key = new Rfc2898DeriveBytes(passwordBytes, _saltBytes, 1000, HashAlgorithmName.SHA256);
      aes.Key = key.GetBytes(aes.KeySize / 8);
      aes.IV = key.GetBytes(aes.BlockSize / 8);
      aes.Mode = CipherMode.CBC;
      using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write)) {
        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
        cs.Close();
      }
      decryptedBytes = ms.ToArray();
    }
    return decryptedBytes;
  }

  public static string DecryptText(string? input) {
    return DecryptText(input, _password);
  }

  public static string DecryptText(string? input, string? password) {
    byte[] bytesToBeDecrypted = Convert.FromBase64String(input ?? string.Empty);
    byte[] passwordBytes = Encoding.UTF8.GetBytes(password ?? _password);
    passwordBytes = SHA256.HashData(passwordBytes);
    byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
    string result = Encoding.UTF8.GetString(bytesDecrypted);
    return result;
  }

}