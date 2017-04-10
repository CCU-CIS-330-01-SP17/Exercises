using System.Security.Cryptography;
using Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptographyTests
{
    [TestClass]
    public class SymmetricEncryptorTests
    {
        [TestMethod]
        public void Can_Encrypt_Decrypt()
        {
            //Set up the encryption.
            var aesCryptoServiceProvider = new AesCryptoServiceProvider();
            var key = aesCryptoServiceProvider.Key;
            var iv = aesCryptoServiceProvider.IV;
            string plainText = "My Plaintext String!";

            //Encrypt and decrypt.
            var encryptedString = SymmetricEncryptor.EncryptString(plainText, key, iv);
            string decryptedString = SymmetricEncryptor.DecryptString(encryptedString, key, iv);
            
            Assert.AreEqual(plainText, decryptedString);
        }
    }
}
