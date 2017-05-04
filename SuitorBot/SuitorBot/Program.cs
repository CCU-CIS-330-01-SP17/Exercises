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
    class Program
    {
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
        static int KelvinToFahrenheight(JToken degrees)
        {
            double kelvin = (double)degrees;
            double fahrenheit = 0;

            fahrenheit = (kelvin * 1.8) - 459.67;

            return (int)fahrenheit;
        }
        static void GetWeatherByZipCode(string location)
        {
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

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/forecast/daily?zip=" + location + ",us&cnt=3&mode=json&appid=05e5cab64950145454f8d6240c841f0d");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            WebRequest request = WebRequest.Create(client.BaseAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            JObject responseFromServer = JObject.Parse(reader.ReadToEnd());

            tempDayOne = KelvinToFahrenheight(responseFromServer.SelectToken("list[0].temp.day"));

            Console.WriteLine("\nWeather was retrieved.");

            Task.WaitAll(
                Task.Run(() => ClothingSelection(tempDayOne, dayOne, location, dateToday)),
                Task.Run(() => ClothingSelection(tempDayTwo, dayTwo, location, dateTomorrow)),
                Task.Run(() => ClothingSelection(tempDayThree, dayThree, location, dateNextDay))
                );

        }
        static void GetWeatherByCity(string location)
        {
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

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/forecast/daily?q=" + location + ",us&cnt=3&mode=json&appid=05e5cab64950145454f8d6240c841f0d");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            WebRequest request = WebRequest.Create(client.BaseAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            JObject responseFromServer = JObject.Parse(reader.ReadToEnd());

            tempDayOne = KelvinToFahrenheight(responseFromServer.SelectToken("list[0].temp.day"));

            Console.WriteLine("\nWeather was retrieved.");
            Task.WaitAll(
                Task.Run(() => ClothingSelection(tempDayOne, dayOne, location, dateToday)),
                Task.Run(() => ClothingSelection(tempDayTwo, dayTwo, location, dateTomorrow)),
                Task.Run(() => ClothingSelection(tempDayThree, dayThree, location, dateNextDay))
                );
        }
        static void ClothingSelection(int temp, string day, string location, DateTime date)
        {
            string top = "";
            string bottom = "";
            string shoes = "";
            string suit = "";


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

            ClothingForDay clothesForTheDay = new ClothingForDay();

            clothesForTheDay.clothingTop = top;
            clothesForTheDay.clothingBottom = bottom;
            clothesForTheDay.clothingFeet = shoes;
            clothesForTheDay.suit = suit;
            //Need to write clothing selection to file and hash location to satisfy cryptography requirement. 
            if (day == "Thursday")
            {
                Console.WriteLine("For today, wear {0} on top, {1} on bottom {2} on your feet. If it is a business day wear your {3}.", top, bottom, shoes, suit);
            }
            else
            {
                Console.WriteLine("For today, wear {0} on top, {1} on bottom {2} on your feet.", top, bottom, shoes);
            }

            WriteFile(clothesForTheDay, location, date);
        }
        static void WriteFile(ClothingForDay clothing, string location, DateTime date)
        {
            byte[] data = Encoding.UTF8.GetBytes(location);
            byte[] hash = SHA256.Create().ComputeHash(data);

            using (FileStream stream = new FileStream(date+".txt", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(date);
                    writer.WriteLine(hash);
                    writer.WriteLine(clothing);
                }
            }
        }
         
        static void Main()
        {
            Console.WriteLine("Welcome agent to your suitor program. My name is Suitor and I will be pleased to tell you what you need to be wearing.");
            Console.Write("Would you like to choose location by city name (1) or zip code(2)? \nPlease enter '1' or '2' respectively:");
            string locationSelection = Console.ReadLine();
            if (locationSelection == "1")
            {
                Console.Write("What city would you like the weather for?");
                string cityLocation = Console.ReadLine();
                LocationByCity city = new LocationByCity(cityLocation);

                //Functioning code at this point.

                GetWeatherByCity(city.cityCode);

            }
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
