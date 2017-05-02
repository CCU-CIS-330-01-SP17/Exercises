using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SuitorBot
{
    public class LocationByZipCode : Location
    {
        public int zipCode { get; set; }

        public LocationByZipCode(int zip)
        : base(zip.ToString())
        {
            if ((zip == null) || (zip.GetType() != typeof(int)))
            {
                throw new ArgumentOutOfRangeException(
                    "Zip Code", zip,
                    "Zip code must be an int and must not be blank or null.");

            }

            //    if (ValidZipCode(zip) == true )
            //    {
            //        zipCode = zip;
            //    }
            //}

            //private bool ValidZipCode(int zip)
            //{
            //    bool isZipCode = false;
            //    try
            //    {
            //        if (Regex.IsMatch(zip.ToString(), @"^(?<Zip>\d{5})$"))
            //        {
            //            isZipCode = true;
            //            return isZipCode;
            //        }
            //    }
            //    catch (ArgumentException e)
            //    {
            //        throw;
            //    }

            //}
        }
    }
}

