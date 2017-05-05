using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Data.SqlClient;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace SuitorBot
{
    /// <summary>
    /// Class that runs the program to get the clothes necessary based upon the weather.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Converts DateTime to a day of the week.
        /// </summary>
        /// <param name="date">DateTime from current date.</param>
        /// <returns></returns>
        static string DateToDayOfWeek(DateTime date)
        {
            string day = "";

            switch ((int)date.DayOfWeek)
            {
                case 0:
                    day = "Sunday";
                    break;
                case 1:
                    day = "Monday";
                    break;
                case 2:
                    day = "Tuesday";
                    break;
                case 3:
                    day = "Wednesday";
                    break;
                case 4:
                    day = "Thursday";
                    break;
                case 5:
                    day = "Friday";
                    break;
                case 6:
                    day = "Saturday";
                    break;
            }
            return day;
        }
        /// <summary>
        /// Converts Kelvin to Fahrenheit.
        /// </summary>
        /// <param name="degrees">Degrees Kelvin to be converted to degrees Fahrenheit.</param>
        /// <returns></returns>
        static int KelvinToFahrenheight(JToken degrees)
        {
            double kelvin = (double)degrees;
            double fahrenheit = 0;

            fahrenheit = (kelvin * 1.8) - 459.67;

            return (int)fahrenheit;
        }
        /// <summary>
        /// Gets weather based on the user input of a zip code.
        /// </summary>
        /// <param name="location">Location in the form of a zip code.</param>
        static void GetWeatherByZipCode(string location)
        {
            //Variables used to get temperature and day of week.
            int tempDayOne = 0;
            int tempDayTwo = 0;
            int tempDayThree = 0;
            DateTime date = DateTime.Now;
            DateTime dateToday = date;
            DateTime dateTomorrow = date.AddDays(1);
            DateTime dateNextDay = date.AddDays(2);
            string dayOne = DateToDayOfWeek(dateToday);
            string dayTwo = DateToDayOfWeek(dateTomorrow);
            string dayThree = DateToDayOfWeek(dateNextDay);

            //Loads the URL to get the weather.
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/forecast/daily?zip=" + location + ",us&cnt=3&mode=json&appid=05e5cab64950145454f8d6240c841f0d");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Gets the weather API from the loaded URL.
            WebRequest request = WebRequest.Create(client.BaseAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            //Reads the API Json return and puts it into a Json object.
            JObject responseFromServer = JObject.Parse(reader.ReadToEnd());

            //Converts the temperature to fahrenheight for each day.
            tempDayOne = KelvinToFahrenheight(responseFromServer.SelectToken("list[0].temp.day"));
            tempDayTwo = KelvinToFahrenheight(responseFromServer.SelectToken("list[1].temp.day"));
            tempDayThree = KelvinToFahrenheight(responseFromServer.SelectToken("list[2].temp.day"));

            Console.WriteLine("\nWeather was retrieved.");

            //Calls the method necessary to get the clothes for today, tomorrow, and the next day.
            Task.WaitAll(
                Task.Run(() => ClothingSelection(tempDayOne, dayOne, location, dateToday)),
                Task.Run(() => ClothingSelection(tempDayTwo, dayTwo, location, dateTomorrow)),
                Task.Run(() => ClothingSelection(tempDayThree, dayThree, location, dateNextDay))
                );

        }
        /// <summary>
        /// Gets weather based on the user input based on the city's name.
        /// </summary>
        /// <param name="location">String variable of the city's name.</param>
        static void GetWeatherByCity(string location)
        {
            //Variables used to get temperature and day of week.
            int tempDayOne = 0;
            int tempDayTwo = 0;
            int tempDayThree = 0;
            DateTime date = DateTime.Now;
            DateTime dateToday = date;
            DateTime dateTomorrow = date.AddDays(1);
            DateTime dateNextDay = date.AddDays(2);
            string dayOne = DateToDayOfWeek(dateToday);
            string dayTwo = DateToDayOfWeek(dateTomorrow);
            string dayThree = DateToDayOfWeek(dateNextDay);

            //Loads the URL to get the weather.
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/forecast/daily?q=" + location + ",us&cnt=3&mode=json&appid=05e5cab64950145454f8d6240c841f0d");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Gets the weather API from the loaded URL.
            WebRequest request = WebRequest.Create(client.BaseAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            //Reads the API Json return and puts it into a Json object.
            JObject responseFromServer = JObject.Parse(reader.ReadToEnd());

            //Converts the temperature to fahrenheight for each day.
            tempDayOne = KelvinToFahrenheight(responseFromServer.SelectToken("list[0].temp.day"));
            tempDayTwo = KelvinToFahrenheight(responseFromServer.SelectToken("list[1].temp.day"));
            tempDayThree = KelvinToFahrenheight(responseFromServer.SelectToken("list[2].temp.day"));

            Console.WriteLine("\nWeather was retrieved.");

            //Calls the method necessary to get the clothes for today, tomorrow, and the next day.
            Task.WaitAll(
                Task.Run(() => ClothingSelection(tempDayOne, dayOne, location, dateToday)),
                Task.Run(() => ClothingSelection(tempDayTwo, dayTwo, location, dateTomorrow)),
                Task.Run(() => ClothingSelection(tempDayThree, dayThree, location, dateNextDay))
                );

        }
        /// <summary>
        /// Selects the clothes necessary for today, tomorrow, and the next day based on the weather conditions.
        /// </summary>
        /// <param name="temp">Int of the temperature in degrees fahrenheight.</param>
        /// <param name="day">String of the day of the week it is to determine what to wear.</param>
        /// <param name="location">String used for naming the file.</param>
        /// <param name="date">DateTime used for naming the file.</param>
        static void ClothingSelection(int temp, string day, string location, DateTime date)
        {
            //Variables to used for the selection of what is going to be worn.
            string top = "";
            string bottom = "";
            string shoes = "";
            string suit = "";

            //Switch case used to select clothes based on the day of the week.
            switch (day)
            {
                case "Sunday":
                    if (temp >= 65)
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                    }
                    break;
                case "Monday":
                    if (temp >= 65)
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                    }
                    break;
                case "Tuesday":
                    if (temp >= 65)
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                    }
                    break;
                case "Wednesday":
                    if (temp >= 65)
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Warm)
                                                                 .Where(c => c.BusinessCasual);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm)
                                                                 .Where(c => c.BusinessCasual);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm)
                                                                 .Where(c => c.BusinessCasual);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                    .Where(c => c.Cold)
                                                                    .Where(c => c.BusinessCasual);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                    .Where(c => c.Cold)
                                                                    .Where(c => c.BusinessCasual);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                    .Where(c => c.Cold)
                                                                    .Where(c => c.BusinessCasual);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                    }
                    break;
                case "Thursday":
                    if (temp >= 65)
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Warm)
                                                                 .Where(c => c.BusinessFormal);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm)
                                                                 .Where(c => c.BusinessFormal);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm)
                                                                 .Where(c => c.BusinessFormal);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Warm)
                                                                 .Where(c => c.BusinessFormal)
                                                                 .Where(c => c.Suit);
                            foreach (var c in clothes)
                            {
                                suit = c.ToString();
                            }
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Cold)
                                                                 .Where(c => c.BusinessFormal);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Cold)
                                                                 .Where(c => c.BusinessFormal);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Cold)
                                                                 .Where(c => c.BusinessFormal);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Cold)
                                                                 .Where(c => c.BusinessFormal)
                                                                 .Where(c => c.Suit);
                            foreach (var c in clothes)
                            {
                                suit = c.ToString();
                            }
                        }
                    }
                    break;
                case "Friday":
                    if (temp >= 65)
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                    }
                    break;
                case "Saturday":
                    if (temp >= 65)
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                top = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                bottom = c.ToString();
                            }
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                    .Where(c => c.Cold);
                            foreach (var c in clothes)
                            {
                                shoes = c.ToString();
                            }
                        }
                    }
                    break;
            }
            Console.WriteLine("Clothing was selected.");

            //Creates an instance for the clothes being worn for the day.
            ClothingForDay clothesForTheDay = new ClothingForDay();

            clothesForTheDay.clothingTop = top;
            clothesForTheDay.clothingBottom = bottom;
            clothesForTheDay.clothingFeet = shoes;
            clothesForTheDay.suit = suit;
            
            //Writes to the console what is going to be worn on that particular day.
            if (day == "Thursday")
            {
                Console.WriteLine("For today, wear {0} on top, {1} on bottom {2} on your feet. If it is a business day wear your {3}.", top, bottom, shoes, suit);
            }
            else
            {
                Console.WriteLine("For today, wear {0} on top, {1} on bottom {2} on your feet.", top, bottom, shoes);
            }

            //Calls the method to write what has been selected to a file.
            WriteFile(clothesForTheDay, location, date);
        }
        /// <summary>
        /// Writes ClothingForDay object to a file based on the location and date.
        /// </summary>
        /// <param name="clothing">ClothingForDay object of clothers to be worn.</param>
        /// <param name="location">String for naming the file.</param>
        /// <param name="date">DateTime for naming the file</param>
        static void WriteFile(ClothingForDay clothing, string location, DateTime date)
        {
            //Hashing the location so that it cannot be determined.
            byte[] data = Encoding.UTF8.GetBytes(location);
            byte[] hash = SHA256.Create().ComputeHash(data);

            using (FileStream stream = new FileStream(date+location+".txt", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(date);
                    writer.WriteLine(hash);
                    writer.WriteLine(clothing);
                }
            }
        }
         
        /// <summary>
        /// Main method that runs the code. 
        /// It accepts user input to determine what code is run.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Welcome agent to your suitor program. My name is Suitor and I will be pleased to tell you what you need to be wearing.");
            Console.Write("Would you like to choose location by city name (1) or zip code(2)? \nPlease enter '1' or '2' respectively:");
            string locationSelection = Console.ReadLine();
            //Selection to enter the city's name.
            if (locationSelection == "1")
            {
                Console.Write("What city would you like the weather for?");
                string cityLocation = Console.ReadLine();
                LocationByCity city = new LocationByCity(cityLocation);

                //Functioning code at this point.

                GetWeatherByCity(city.cityCode);

            }
            //Selection to enter the zip code of the city.
            if (locationSelection == "2")
            {
                Console.Write("What city would you like the weather for?");
                string cityLocation = Console.ReadLine();
                LocationByZipCode city = new LocationByZipCode(cityLocation);

                //Functioning code at this point.

                GetWeatherByZipCode(city.zipCode);
            }

            Console.ReadKey();
        }
    }
}
