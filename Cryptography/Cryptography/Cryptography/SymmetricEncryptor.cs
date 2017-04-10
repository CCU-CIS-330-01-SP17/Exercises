using System.IO;
using System.Security.Cryptography;

namespace Cryptography
{
    /// <summary>
    /// Encrypts and Decrypts objects symmetrically.
    /// </summary>
    public static class SymmetricEncryptor
    {
        /// <summary>
        /// Takes a string and encrypts it using symmetric encryption.
        /// </summary>
        /// <param name="plainText">The string to encrypt.</param>
        /// <param name="key">The key for the encrypion.</param>
        /// <param name="iv">The iv for the encryption.</param>
        /// <returns></returns>
        public static byte[] EncryptString(string plainText, byte[] key, byte[] iv)
        {
            using (var csp = new AesCryptoServiceProvider())
            {
                var encryptor = csp.CreateEncryptor(key, iv);

                // Create the streams used for encryption.
                using (var stream = new MemoryStream())
                using (var crypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    using (var writer = new StreamWriter(crypt))
                    {
                        writer.Write(plainText);
                    }

                    return stream.ToArray();
                }
            }
        }

        /// <summary>
        /// Decrypts an encrypted string
        /// </summary>
        /// <param name="encryptedString">The encrypted string</param>
        /// <param name="key">The key to use for decryption.</param>
        /// <param name="iv">The iv to use for decryption.</param>
        /// <returns></returns>
        public static string DecryptString(byte[] encryptedString, byte[] key, byte[] iv)
        {
            using (var csp = new AesCryptoServiceProvider())
            {
                var decryptor = csp.CreateDecryptor(key, iv);

                // Create the streams for decryption.
                using (var stream = new MemoryStream(encryptedString))
                using (var crypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(crypt))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
