using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptographyCodingExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using static CryptographyCodingExercise.CryptographyAssignment;

namespace CryptographyCodingExercise.Tests
{
    /// <summary>
    /// This class contains tests for all methods in the <see cref="CryptographyAssignment"/> class.
    /// </summary>
    [TestClass()]
    public class CryptographyAssignmentTests
    {
        /// <summary>
        /// This method tests to see if the HashItem method returns the correct value.
        /// </summary>
        [TestMethod()]
        public void HashItemTest()
        {
            string unhashedItem = "Christopher";
            // Hash the string using the HashItem method.
            byte[] hashedItem = new CryptographyAssignment().HashItem(unhashedItem);
            // Hash the string a second time in order to determine that both hashes match.
            byte[] dataToHash = Encoding.UTF8.GetBytes(unhashedItem);
            byte[] hashedItem2 = SHA256.Create().ComputeHash(dataToHash);
            Console.Write(Encoding.UTF8.GetString(hashedItem) + "\n" + Encoding.UTF8.GetString(hashedItem2));
            Assert.AreEqual(true, hashedItem.SequenceEqual(hashedItem2));
        }

        /// <summary>
        /// This method tests to see if the SystematicEncryptItem and SystematicDecryptItem methods work as intended.
        /// </summary>
        [TestMethod()]
        public void SystematicEncryptDecryptItemTest()
        {
            string plainText = "Christopher Parker";
            SystematicEncryptReturnedValues returnedValues = new CryptographyAssignment().SystematicEncryptItem(plainText);
            string decryptedValue = new CryptographyAssignment().SystematicDecryptItem(returnedValues.encryptedValue, returnedValues.key, returnedValues.iv);
            Console.WriteLine("Plain text: {0}", plainText);
            Console.WriteLine("Encrypted value: {0}", Encoding.UTF8.GetString(returnedValues.encryptedValue));
            Console.WriteLine("Decrypted value: {0}", decryptedValue);
            Assert.AreEqual(plainText, decryptedValue);
        }
    }
}