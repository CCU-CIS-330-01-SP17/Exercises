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

namespace SuitorBot
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<Weather> GetWeatherAsync(string path)
        {
            Weather todayWeather = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string weatherJson = await response.Content.ReadAsStringAsync();
                todayWeather = JsonConvert.DeserializeObject<Weather>(weatherJson);

                //Debugging purposes.
                Console.WriteLine("\nAttempting to view parse data from api.");
                Console.WriteLine("\n" + todayWeather);
            }
            return todayWeather;
        }
        static async Task RunAsync(string location)
        {
            //Uri works properly.
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/forecast?q=" + location + ",us&mode=json&appid=05e5cab64950145454f8d6240c841f0d");

            //Debuging puroses.
            Console.WriteLine(client.BaseAddress);

            Console.WriteLine("\nWeb address successful.");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Weather newWeather = await GetWeatherAsync(client.BaseAddress.ToString());

            Console.WriteLine(newWeather.ToString());
        }
        static void ClothingSelection(int temp, DateTime date)
        {
            int tempMax = 77;
            DateTime dateNow = date;
            string day = null;
            string top = null;
            string bottom = null;
            string shoes = null;
            string suit = null;

            switch((int)dateNow.DayOfWeek)
            {
                case 1:
                    day = "Sunday";
                    break;
                case 2:
                    day = "Monday";
                    break;
                case 3:
                    day = "Tuesday";
                    break;
                case 4:
                    day = "Wednesday";
                    break;
                case 5:
                    day = "Thursday";
                    break;
                case 6:
                    day = "Friday";
                    break;
                case 7:
                    day = "Saturday";
                    break;
            }
            switch (day)
            {
                case "Sunday":
                    if (tempMax >= 65)
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Warm);
                            foreach(var c in clothes)
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
                                bottom =  c.ToString();
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
                    if (tempMax >= 65)
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
                    if (tempMax >= 65)
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
                    if (tempMax >= 65)
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
                    if (tempMax >= 65)
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
                            foreach(var c in clothes)
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
                    if (tempMax >= 65)
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
                    if (tempMax >= 65)
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
            Console.WriteLine("For today, wear {0} on top, {1} on bottom {2} on your feet. If it is a business day wear your {3}.", top, bottom, shoes, suit);
        }
        static void Main()
        {
            Console.Write("Would you like to choose location by city name (1) or zip code(2)? \nPlease enter '1' or '2' respectively:");
            string locationSelection = Console.ReadLine();
            if (locationSelection == "1")
            {
                Console.Write("What city would you like the weather for?");
                string cityLocation = Console.ReadLine();
                LocationByCity city = new LocationByCity(cityLocation);

                //Functioning code at this point.

                RunAsync(city.cityCode).Wait();

            }
            if (locationSelection == "2")
            {
                Console.Write("What city would you like the weather for?");
                string cityLocation = Console.ReadLine();
                LocationByZipCode city = new LocationByZipCode(cityLocation);

                //Functioning code at this point.

                RunAsync(city.zipCode).Wait();
            }


            Console.ReadKey();
        }
    }
}
