using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SuitorBot
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static string cityLocation = "Denver";

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
        static async Task RunAsync()
        {
            //Uri works properly.
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/forecast?q=" + cityLocation + ",us&mode=json&appid=05e5cab64950145454f8d6240c841f0d");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Weather newWeather = await GetWeatherAsync(client.BaseAddress.ToString());

            Console.WriteLine(newWeather.ToString());
        }
        static void Main()
        {
            RunAsync().Wait();

            Console.ReadKey();
        }        
    }
}
