using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptographyCodingExerciseWeek13;

namespace CryptographyCodingExerciseWeek13Test
{
    /// <summary>
    /// Classt that tests the different types of encryption.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests Hashing encryption.
        /// Tests to see if the hashing of the same text is equal.
        /// </summary>
        [TestMethod]
        public void HashTestMethod()
        {
            string text = "This is my super secret message that I need to encrypt.";

            byte[] hash1 = Hashing.HashEncrypt(text);
            byte[] hash2 = Hashing.HashEncrypt(text);

            Assert.IsTrue(hash1.SequenceEqual(hash2));
        }
        /// <summary>
        /// Test Symmetric encryption.
        /// Tests to see if the encrypted text is the same as the decrypted text.
        /// </summary>
        [TestMethod]
        public void SymmetricTestMethod()
        {
            string text = "This is my super secret message that I need to encrypt.";

            string encryptedText = Symmetric.SymmetricEncrypt(text);

            Assert.AreEqual(text, encryptedText);
        }
        /// <summary>
        /// Tests Assymetric encryption.
        /// Tests to see if the encrypted text is the same as the decrypted text.
        /// </summary>
        [TestMethod]
        public void AssymetricTestMethod()
        {
            string text = "This is my super secret message that I need to encrypt.";

            string encryptedText = Assymetric.AssymetricEncrypt(text);

            Assert.AreEqual(text, encryptedText);

        }
        /// <summary>
        /// Tests the digital signature to see if it is a valid signature. 
        /// </summary>
        [TestMethod]
        public void DigitalSigningTestMethod()
        {
            string text = "This is my super secret message that I need to encrypt.";

            bool encryptedText = DigitalSigning.DigitalSignEncrypt(text);

            Assert.IsTrue(encryptedText);
        }
    }
}
