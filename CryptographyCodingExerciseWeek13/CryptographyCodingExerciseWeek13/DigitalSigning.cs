using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;

namespace CryptographyCodingExerciseWeek13
{
    /// <summary>
    /// Class that digitally signs information.
    /// </summary>
    public class DigitalSigning
    {
        /// <summary>
        /// Method digitally signs and encrypts information that is passed in.  
        /// </summary>
        /// <param name="someText">String variable that gets passed in to be encrypted.</param>
        /// <returns>Returns bool variable isVlaid for evaluation.</returns>
        public static bool DigitalSignEncrypt(string someText)
        {
            string textToEncrypt = someText;
            string sha256Id = CryptoConfig.MapNameToOID("SHA256");
            string privateKey;
            string publicKey;
            byte[] signature;
            bool isValid;

            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                publicKey = csp.ToXmlString(false);
                privateKey = csp.ToXmlString(true);
            }

            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(privateKey);

                signature = csp.SignData(Encoding.UTF8.GetBytes(textToEncrypt), sha256Id);
            }

            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(publicKey);

                isValid = csp.VerifyData(Encoding.UTF8.GetBytes(textToEncrypt), sha256Id, signature);
            }
            return isValid;
        }
    }
}
