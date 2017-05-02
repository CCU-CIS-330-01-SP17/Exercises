using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Data.SqlClient;

namespace SuitorBot
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<Weather> GetWeatherAsync(string path)
        {
            Weather todayWeather = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if(response.IsSuccessStatusCode)
            {
                todayWeather = await response.Content.ReadAsAsync<Weather>();
            }
            return todayWeather;
        }
        static async Task RunAsync(string location)
        {
            //Uri works properly.
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/forecast?q=" + location + ",us&mode=json&appid=05e5cab64950145454f8d6240c841f0d");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Weather newWeather = await GetWeatherAsync(client.BaseAddress.ToString());

            Console.WriteLine(newWeather.ToString());
        }
        static void ClothingSelection(int temp, string date)
        {
            int tempMax = 77;
            string dateNow;
            string top;
            string bottom;
            string shoes;
            string suit;

            //SqlConnection clothingDB = new SqlConnection("Clothing.mdf");

            switch (string dateNow)
            {
                case "Sunday":
                    if (tempMax >= 65)
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                    }
                    else
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                    }
                    break;
                case "Monday":
                    if (tempMax >= 65)
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                    }
                    else
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                    }
                    break;
                case "Tuesday":
                    if (tempMax >= 65)
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                    }
                    else
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                    }
                    break;
                case "Wednesday":
                    if (tempMax >= 65)
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Warm = 1 and c.BusinessCasual = 1);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Warm = 1 and c.BusinessCasual = 1);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Warm = 1 and c.BusinessCasual = 1);
                    }
                    else
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Cold = 1 and c.BusinessCasual = 1);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Cold = 1 and c.BusinessCasual = 1);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Cold = 1 and c.BusinessCasual = 1);
                    }
                    break;
                case "Thursday":
                    if (tempMax >= 65)
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Warm = 1 and c.BusinessFormal = 1);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Warm = 1 and c.BusinessFormal = 1);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Warm = 1 and c.BusinessFormal = 1);
                    }
                    else
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Cold = 1 and c.BusinessFormal = 1);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Cold = 1 and c.BusinessFormal = 1);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Cold = 1 and c.BusinessFormal = 1);
                    }
                    break;
                case "Friday":
                    if (tempMax >= 65)
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                    }
                    else
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                    }
                    break;
                case "Saturday":
                    if (tempMax >= 65)
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Warm = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                    }
                    else
                    {
                        top = clothing.Where(c => c.ClothingTop = 1 and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        bottom = clothing.Where(c => c.ClothingBottom = 1 and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                        shoes = clothing.Where(clothingDB => c.ClothingFeet = 1and c.Cold = 1 and c.BusinessCasual = 0 and c.BusinessFormal = 0);
                    }
                    break;
            }
        }
        static void Main()
        {
            Console.Write("Would you like to choose location by city name or zip code? \nPlease enter '1' or '2' respectively:");
            string locationSelection = Console.ReadLine();
            if (locationSelection == "1")
            {
                Console.Write("What city would you like the weather for?");
                LocationByCity city = new LocationByCity(Console.ReadLine());

                RunAsync(city.cityCode).Wait();
                    
            }
            if (locationSelection == "2")
            {
                Console.Write("What city would you like the weather for?");
                LocationByZipCode city = new LocationByZipCode(Console.ReadLine());

                RunAsync(city.zipCode ).Wait();
            }
            

            Console.ReadKey();
        }        
    }
}
