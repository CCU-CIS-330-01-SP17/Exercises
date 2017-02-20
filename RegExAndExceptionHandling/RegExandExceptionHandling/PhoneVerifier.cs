using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExandExceptionHandling
{
    /// <summary>
    /// Verifies phone numbers using RegEx
    /// </summary>
    public static class PhoneVerifier
    {
        /// <summary>
        /// Uses RegEx to verify is a string follows the format of a phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number to verify.</param>
        /// <returns>Whether the string is a phone number.</returns>
        public static bool IsValidNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Parameter phoneNumber is Empty, Null, or Whitespace.");

            /*Regex Explanation:
             * ^ - Beginning of String
             * (\+1| - First half of a group, literal +1 as first option
             * 1)? - Second half of group, literal 1 as secon option. Zero or one repetitions of group.
             * [\s-./]? - Both options are followed by Zero or One Whitespace, hyphen, dot, or forward slash
             * (\(\d{3}\)| - First half of a group, the first option requring parenthasis around exactly 3 digits
             * \d{3}) - Second half of a group, the second option being exactly three digits (no parenthasis)
             * [\s-./]? - One or Zero of Whitespace, hyphens, dots, or forward slash
             * \d{3} - Exactly three digits
             * [\s-./]? - One or Zero of Whitespace, hyphens, dots, or forward slash
             * \d{4} - Exactly four digits
             * $ - End of string
            */
            var phoneValidator = new Regex(@"^(\+1[\s-./]?|1[\s-./]?)?(\(\d{3}\)|\d{3})[\s-./]?\d{3}[\s-./]?\d{4}$");
            return phoneValidator.IsMatch(phoneNumber);
        }
    }
}
