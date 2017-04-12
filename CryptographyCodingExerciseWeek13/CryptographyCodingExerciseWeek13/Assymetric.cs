using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
namespace CryptographyCodingExerciseWeek13
{
    /// <summary>
    /// Class that encrypts a string via Assymetric Encryption.
    /// </summary>
    public class Assymetric
    {
        /// <summary>
        /// Method that takes a string parameter and encrypts the parameter using assymetric encryption.
        /// </summary>
        /// <param name="someText">String variable that gets passed in to be encrypted.</param>
        /// <returns>String variable, decryptedValue is returned for evaluation.</returns>
        public static string AssymetricEncrypt(string someText)
        {
            string textToEncrypt = someText;
            string privateKey;
            string publicKey;
            byte[] encryptedValue;
            string decryptedValue;

            //Encrypt variable using assymetric encryption.
            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                publicKey = csp.ToXmlString(false);
                privateKey = csp.ToXmlString(true);
            }

            //Decrypting the encrypted information using assymetric encryption.
            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(publicKey);

                encryptedValue = csp.Encrypt(Encoding.UTF8.GetBytes(textToEncrypt), true);
            }

            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(privateKey);

                decryptedValue = Encoding.UTF8.GetString(csp.Decrypt(encryptedValue, true));
            }

            return decryptedValue;
        }
    }
}
