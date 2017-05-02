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
                Console.WriteLine("Attempting to view parse data from api.");
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

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Weather newWeather = await GetWeatherAsync(client.BaseAddress.ToString());

            Console.WriteLine(newWeather.ToString());
        }
        static void ClothingSelection(int temp, string date)
        {
            int tempMax = 77;
            string dateNow = date;
            string top;
            string bottom;
            string shoes;
            string suit;


            switch (dateNow)
            {
                case "Sunday":
                    if (tempMax >= 65)
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Warm);
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm);
                            shoes = clothes.ToString();
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                    .Where(c => c.Cold);
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                    .Where(c => c.Cold);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                    .Where(c => c.Cold);
                            shoes = clothes.ToString();
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
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm);
                            shoes = clothes.ToString();
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                    .Where(c => c.Cold);
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                    .Where(c => c.Cold);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                    .Where(c => c.Cold);
                            shoes = clothes.ToString();
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
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm);
                            shoes = clothes.ToString();
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                    .Where(c => c.Cold);
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                    .Where(c => c.Cold);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                    .Where(c => c.Cold);
                            shoes = clothes.ToString();
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
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm)
                                                                 .Where(c => c.BusinessCasual);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm)
                                                                 .Where(c => c.BusinessCasual);
                            shoes = clothes.ToString();
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                    .Where(c => c.Cold)
                                                                    .Where(c => c.BusinessCasual);
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                    .Where(c => c.Cold)
                                                                    .Where(c => c.BusinessCasual);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                    .Where(c => c.Cold)
                                                                    .Where(c => c.BusinessCasual);
                            shoes = clothes.ToString();
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
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm)
                                                                 .Where(c => c.BusinessFormal);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm)
                                                                 .Where(c => c.BusinessFormal);
                            shoes = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Warm)
                                                                 .Where(c => c.BusinessFormal)
                                                                 .Where(c => c.Suit);
                            suit = clothes.ToString();
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Cold)
                                                                 .Where(c => c.BusinessFormal);
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Cold)
                                                                 .Where(c => c.BusinessFormal);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Cold)
                                                                 .Where(c => c.BusinessFormal);
                            shoes = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                 .Where(c => c.Cold)
                                                                 .Where(c => c.BusinessFormal)
                                                                 .Where(c => c.Suit);
                            suit = clothes.ToString();
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
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm);
                            shoes = clothes.ToString();
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                    .Where(c => c.Cold);
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                    .Where(c => c.Cold);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                    .Where(c => c.Cold);
                            shoes = clothes.ToString();
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
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                 .Where(c => c.Warm);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                 .Where(c => c.Warm);
                            shoes = clothes.ToString();
                        }
                    }
                    else
                    {
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingTop)
                                                                    .Where(c => c.Cold);
                            top = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingBottom)
                                                                    .Where(c => c.Cold);
                            bottom = clothes.ToString();
                        }
                        using (ClothingEntities entities = new ClothingEntities())
                        {
                            var clothes = entities.ClothesToWears.Where(c => c.ClothingFeet)
                                                                    .Where(c => c.Cold);
                            shoes = clothes.ToString();
                        }
                    }
                    break;
            }
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
