using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SuitorBot
{
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

        //    if (ValidCity(city) == true)
        //    {
        //        cityCode = city;
        //    }
        //}
        //private bool ValidCity(string city)
        //{
        //    bool isCity = false;
        //    try
        //    {
        //        if (Regex.IsMatch(city, @"(^[a-zA-Z])$"))
        //        {
        //            isCity = true;
        //            return isCity;
        //        }
        //    }
        //    catch (ArgumentException e)
        //    {
        //        throw;
        //    }
        }
    }
}
