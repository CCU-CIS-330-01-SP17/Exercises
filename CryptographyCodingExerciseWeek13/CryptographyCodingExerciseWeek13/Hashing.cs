using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;

namespace CryptographyCodingExerciseWeek13
{
    /// <summary>
    /// Class that encrypts a string via Hashing.
    /// </summary>
    public class Hashing
    {
        /// <summary>
        /// Method that takes a string parameter and encrypts the parameter using Hashing.
        /// </summary>
        /// <param name="someText">String variable that gets passed in to be encrypted.</param>
        public static byte[] HashEncrypt(string someText)
        {
            string textToEncrypt = someText;
            byte[] data = Encoding.UTF8.GetBytes(textToEncrypt);
            byte[] hash = SHA256.Create().ComputeHash(data);

            return hash;
        }
    }
}
