using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SuitorBot
{
    /// <summary>
    /// Class that is used for Json deserialization. 
    /// </summary>
    public class Weather
    {
        string location { get; set; }
        string dayOfWeek { get; set; }
        string temp { get; set; }
        string temp_min { get; set; }
        string temp_Max { get; set; }
        string weather { get; set; }
        string dt_txt { get; set; }
    }

        //"http://api.openweathermap.org/data/2.5/forecast?q="+cityLocation+",us&mode=json");
    //api.openweathermap.org/data/2.5/forecast?id={city ID} 

}

