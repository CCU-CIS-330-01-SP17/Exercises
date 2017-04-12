using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;

namespace CryptographyCodingExerciseWeek13
{
    /// <summary>
    /// Class that encrypts a string via Symmetric Encryption.
    /// </summary>
    public class Symmetric
    {
        /// <summary>
        /// Method that takes a string parameter and encrypts the parameter using symmetric encryption.
        /// </summary>
        /// <param name="someText">String variable that gets passed in to be encrypted.</param>
        /// <returns>String variable, decryptedValue is returned for evaluation.</returns>
        public static string SymmetricEncrypt(string someText)
        {
            string textToEncrypt = someText;
            byte[] encryptedValue;
            string decryptedValue;

            byte[] key;
            byte[] iv;

            //Encrypt variable using symmetric encryption.
             using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
            {
                key = csp.Key;
                iv = csp.IV;

                ICryptoTransform encryptor = csp.CreateEncryptor(key, iv);

                using (MemoryStream stream = new MemoryStream())
                using (CryptoStream crypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(crypt))
                    {
                        writer.Write(textToEncrypt);
                    }
                    encryptedValue = stream.ToArray();
                }
            }

             //Decrypt encrypted information using symmetric encryption.
            using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
            {
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
    }
}
