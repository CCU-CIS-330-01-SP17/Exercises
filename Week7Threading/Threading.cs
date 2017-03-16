using System;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Linq;

namespace Week7Threading
{
    /// <summary>
    /// Threading housing is used so that Week7ThreadingTest can test the methods.
    /// Public static async Task<string> RunProgram(List<string> websites) calls CheckUrl(urlList) and returns true once it finishes.
    /// Static async Task CheckUrl(List<string> websites) tests the download speed of the website. 
    /// </summary>
    public class Threading
    {
        public static async Task<string> RunProgram(List<string> websites)
        {
            var urlList = websites;
            await CheckUrl(urlList);
            return await Task.FromResult("true");
        }
        static async Task CheckUrl(List<string> websites)
        {
            List<Task> tasks = new List<Task>();

            List<string> urlList = websites;

            //var urlList = new[]
            //{
            //    "https://www.google.com/",
            //    "https://www.microsoft.com/",
            //    "https://www.yahoo.com/",
            //    "http://www.bing.com/",
            //    "https://www.facebook.com/",
            //    "https://www.espn.com",
            //    "https://www.pinterest.com/",
            //    "https://collaborateworship.com/reverb/"
            //};

            for (int i = 0; i < urlList.Count; i++)
            {
                tasks.Add(Task.Run(() => WebsiteDownload(urlList[i])));
            }

            await Task.WhenAll(tasks);
            Console.Write("Finished thread.");
            Console.ReadKey();
        }

        public static Task CheckUrl(string[] urlList)
        {
            throw new NotImplementedException();
        }

        static void WebsiteDownload(string website)
        {
            WebClient client = new WebClient();

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stopwatch sw = new Stopwatch();

            sw.Start();

            Stream newWebsite = client.OpenRead(@website);
            StreamReader reader = new StreamReader(newWebsite);
            string result = reader.ReadToEnd();

            sw.Stop();

            Console.WriteLine("Time elapsed: " + website + ": {0} millseconds.", sw.ElapsedMilliseconds);
        }
    }
}