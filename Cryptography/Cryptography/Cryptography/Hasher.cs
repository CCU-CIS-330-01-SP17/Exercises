using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    /// <summary>
    /// Takes input and performs hashing operations on it.
    /// </summary>
    public static class Hasher
    {
        /// <summary>
        /// Hashes the input string using SHA256.
        /// </summary>
        /// <param name="input">The string input to hash.</param>
        /// <returns>The hashed string.</returns>
        public static string Hash(string input)
        {
            var data = Encoding.UTF8.GetBytes(input);
            var hash = SHA256.Create().ComputeHash(data);
            return Encoding.UTF8.GetString(hash);
        }

        /// <summary>
        /// Hashes the input bytes using SHA256
        /// </summary>
        /// <param name="input">The byte array input to hash.</param>
        /// <returns>The hashed byte array.</returns>
        public static byte[] Hash(byte[] input)
        {
            return SHA256.Create().ComputeHash(input);
        }
    }
}
