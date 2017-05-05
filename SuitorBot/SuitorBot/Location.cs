using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitorBot
{
    /// <summary>
    /// Class that identifies the location that user wants the weather for.
    /// </summary>
    public class Location
    {
        public string userLocation { get; set; }

        public Location(string location)
        {
            userLocation = location;
        }

    }
    //Location by zip code.
    //@"^(?<Zip>\d{5})$"

    //Location by city.
    //@"(^[a-zA-Z])$"
}
