using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SuitorBot
{
    /// <summary>
    /// Class that identifies the location that user wants the weather for based on the city's name.
    /// </summary>
    public class LocationByCity : Location
    {
        public string cityCode { get; set; }

        public LocationByCity (string city)
        : base (city)
        {
            if ((city == null) || (city.GetType() != typeof(string)))
            {
                throw new ArgumentOutOfRangeException(
                    "City", city,
                    "City must be a string and must not be blank or null.");
            }

            if (ValidCity(city) == true)
            {
                cityCode = city;
            }
        }
        /// <summary>
        /// Validates the user's input for alapha characters only.
        /// </summary>
        /// <param name="city">String of the city's name.</param>
        /// <returns></returns>
        private bool ValidCity(string city)
        {
            bool isCity = false;
            try
            {
                if (Regex.IsMatch(city, @"^([a-zA-Z])$"))
                {
                    isCity = true;
                    return isCity;
                }
                else
                {
                    return isCity;
                }
            }
            catch (ArgumentException )
            {
                throw;
            }
        }
    }
}
