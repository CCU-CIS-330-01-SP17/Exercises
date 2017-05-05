using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SuitorBot
{
    /// <summary>
    /// Class that identifies the location that user wants the weather for based the city's zip code.
    /// </summary>
    public class LocationByZipCode : Location
    {
        public string zipCode { get; set; }

        public LocationByZipCode(string zip)
        : base(zip)
        {
            if ((zip == null) || (zip.GetType() != typeof(string)))
            {
                throw new ArgumentOutOfRangeException(
                    "Zip Code", zip,
                    "Zip code must be an int and must not be blank or null.");

            }

            if (ValidZipCode(zip) == true)
            {
                zipCode = zip;
            }
        }
        /// <summary>
        /// Validates the user's input based on the city's zip code using 5 digit zip code.
        /// </summary>
        /// <param name="zip">String of the zip code of the ciyt.</param>
        /// <returns></returns>
        private bool ValidZipCode(string zip)
        {
            bool isZipCode = false;
            try
            {
                if (Regex.IsMatch(zip.ToString(), @"^(?<Zip>\d{5})$"))
                {
                    isZipCode = true;
                    return isZipCode;
                }
                else
                {
                    return isZipCode;
                }
            }
            catch (ArgumentException)
            {
                throw;
            }

        }
    }
}

