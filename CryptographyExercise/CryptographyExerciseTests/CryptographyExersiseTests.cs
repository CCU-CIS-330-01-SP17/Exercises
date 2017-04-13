using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptographyExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CryptographyExercise.Tests
{
    /// <summary>
    /// This class cobntains methods for testing the methods in the <see cref="CryptographyExersise"/> class.
    /// </summary>
    [TestClass()]
    public class CryptographyExersiseTests
    {
        /// <summary>
        /// This method tests to make sure that the HashPassword method correctly hashes a string.
        /// </summary>
        [TestMethod()]
        public void HashPasswordTest()
        {
            string password = "ABC1234";
            byte[] hashedPassword = new CryptographyExersise().HashPassword(password);
            Console.WriteLine(Encoding.UTF8.GetString(hashedPassword));
            // Hash the password string again, and compare the hashed byte arrays for equality.
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] hashedPassword2 = SHA256.Create().ComputeHash(data);
            Console.WriteLine(Encoding.UTF8.GetString(hashedPassword2));
            Assert.AreEqual(true, hashedPassword.SequenceEqual(hashedPassword2));
        }

        /// <summary>
        /// This method tests to make sure that both the EncryptValue and DecryptValue methods work correctly.
        /// </summary>
        [TestMethod()]
        public void EncryptDecryptValueTest()
        {
            string plainText = "Christopher Parker";
            ICryptoTransform encryptor;
            ICryptoTransform decryptor;
            // Generate an encryptor and decryptor object using the same key and iv.
            using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
            {
                byte[] key = csp.Key;
                byte[] iv = csp.IV;
                encryptor = csp.CreateEncryptor(key, iv);
                decryptor = csp.CreateDecryptor(key, iv);
            }
            // Encrypt the plainText string.
            byte[] encryptedText = new CryptographyExersise().EncryptValue(plainText, encryptor);
            // Decrypt the encryptedText byte array.
            string decryptedText = new CryptographyExersise().DecryptValue(encryptedText, decryptor);
            // Write the results to console.
            Console.WriteLine("Plain text: {0}", plainText);
            Console.WriteLine("Encrypted value: {0}", Encoding.UTF8.GetString(encryptedText));
            Console.WriteLine("Decrypted value: {0}", decryptedText);
            // Assert that the plainText and decryptedText values are equal
            Assert.AreEqual(plainText, decryptedText);
        }
    }
}