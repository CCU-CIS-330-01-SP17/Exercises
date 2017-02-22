using System;
using System.Text.RegularExpressions;
namespace RegexExceptionHandling
{
    /// <summary>
    /// This class containes all methods used to validate phone numbers via regular expressions.
    /// </summary>
    public class PhoneValidator
    {
        /// <summary>
        /// This method validates a single phone number using regular expressions.
        /// </summary>
        /// <param name="numberToValidate"></param>
        /// <returns></returns>
        public bool validatePhoneNumber(string numberToValidate)
        {
            // This regular expression validates 10 & 11 digit US telephone numbers.
            Regex phoneNumberExpression7 =
                new Regex(@"^(?:\+?1[-/. ]?)?\(?([0-9]{3})\)?[-/. ]?([0-9]{3})[-/. ]?([0-9]{4})$");

            // This regular expression validates 7 digit US telephone numbers.
            Regex phoneNumberExpression5 =
                new Regex(@"^([0-9]{3})[-/. ]?([0-9]{4})$");

            if (numberToValidate == null)
            {
                throw new ArgumentNullException();
            }
            else if (phoneNumberExpression7.IsMatch(numberToValidate) == false)
            {
                if (phoneNumberExpression5.IsMatch(numberToValidate) == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
};
