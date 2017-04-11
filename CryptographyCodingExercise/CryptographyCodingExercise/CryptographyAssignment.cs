using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyCodingExercise
{
    /// <summary>
    /// This class contains code for the implementation of a Hashing method and Symmetric Encryption/Decryption method.
    /// </summary>
    public class CryptographyAssignment
    {
        /// <summary>
        /// This method takes a string as a parameter, and returns the hashed result as a byte array.
        /// </summary>
        /// <param name="itemToHash"></param>
        /// <returns></returns>
        public byte[] HashItem(string itemToHash)
        {
            byte[] data = Encoding.UTF8.GetBytes(itemToHash);
            byte[] hashedItem = SHA256.Create().ComputeHash(data);
            return hashedItem;
        }

        /// <summary>
        /// This method takes a string as a parameter, encrypts it, and returns an array of objects with the  encrypted result as well as the Key/IV used for encryption.
        /// </summary>
        /// <param name="itemToEncrypt"></param>
        /// <returns></returns>
        public SystematicEncryptReturnedValues SystematicEncryptItem(string itemToEncrypt)
        {
            byte[] encryptedValue;
            byte[] key;
            byte[] iv;
            using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
            {
                // Generate Key and IV
                key = csp.Key;
                iv = csp.IV;
                // Create the encryptor object and the streams for encryption.
                ICryptoTransform encryptor = csp.CreateEncryptor(key, iv);
                using (MemoryStream stream = new MemoryStream())
                using (CryptoStream crypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(crypt))
                    {
                        writer.Write(itemToEncrypt);
                    }
                    encryptedValue = stream.ToArray();
                }
            }
            SystematicEncryptReturnedValues returnedValues = new SystematicEncryptReturnedValues();
            returnedValues.encryptedValue = encryptedValue;
            returnedValues.key = key;
            returnedValues.iv = iv;
            return returnedValues;
        }

        /// <summary>
        /// This method takes an encryped array of bytes as well as the key and iv, then decrypts it and returns the result as a string 
        /// </summary>
        /// <param name="encryptedValue"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public string SystematicDecryptItem(byte[] encryptedValue, byte[] key, byte[] iv)
        {
            string decryptedValue;
            using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
            {
                // Create the decryptor object and the streams for decryption.
                ICryptoTransform decryptor = csp.CreateDecryptor(key, iv);
                using (MemoryStream stream = new MemoryStream(encryptedValue))
                using (CryptoStream crypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                using (StreamReader reader = new StreamReader(crypt))
                {
                    decryptedValue = reader.ReadToEnd();
                }
            }
            return decryptedValue;
        }

        /// <summary>
        /// This class represents the values returned in the SystematicEncryptItem method.
        /// </summary>
        public class SystematicEncryptReturnedValues
        {
            /// <summary>
            /// Represents the value after encryption
            /// </summary>
            public byte[] encryptedValue { get; set; }

            /// <summary>
            /// Represents the key used for encryption.
            /// </summary>
            public byte[] key { get; set; }

            /// <summary>
            /// Represents the iv used for encryption.
            /// </summary>
            public byte[] iv { get; set; }
        }
    }
}
