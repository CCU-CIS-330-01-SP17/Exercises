using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegularExpressionAndExceptionHandling
{
    /// <summary>
    /// ValidPhoneNumber class uses a regular expression to validate all valid forms of United States phone numbers.
    /// It passes in a string, phoneNumber, to validate against a pattern. 
    /// </summary>
    public static class ValidPhoneNumber
    {
        public static bool PhoneNumber(string phoneNumber)
        {
           return Regex.IsMatch(phoneNumber, @"^(?:\+?(1))?[-./ (]*(\d{3})?[-./ )]*(\d{3})[-./ ]*(\d{4})*$");
            
        }
    }
}
