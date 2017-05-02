using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitorBot
{
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
