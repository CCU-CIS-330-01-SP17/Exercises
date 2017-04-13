using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyExercise
{
    /// <summary>
    /// This class contains the methods for implementing hashing and symmetric encryption/decryption.
    /// </summary>
    public class CryptographyExersise
    {
        /// <summary>
        /// This method hashes a password string and returnes the hashed byte array.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public byte[] HashPassword(string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.Create().ComputeHash(data);
            return hash;
        }
        /// <summary>
        /// This method encrypts a string using Systematic Encryption.
        /// </summary>
        /// <returns></returns>
        public byte[] EncryptValue(string plainText, ICryptoTransform encryptor)
        {
            using (MemoryStream stream = new MemoryStream())
            using (CryptoStream crypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter writer = new StreamWriter(crypt))
                {
                    writer.Write(plainText);
                }
                return stream.ToArray();
            }
        }
        /// <summary>
        /// This method decrypts a Systematically Encrypted byte array.
        /// </summary>
        /// <param name="encryptedValue"></param>
        /// <param name="decryptor"></param>
        /// <returns></returns>
        public string DecryptValue (byte[] encryptedValue, ICryptoTransform decryptor)
        {
            using (MemoryStream stream = new MemoryStream(encryptedValue))
            using (CryptoStream crypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
            using (StreamReader reader = new StreamReader(crypt))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
