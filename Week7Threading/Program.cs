using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;

namespace Week7Threading
{
    class Program
    {
        /// <summary>
        /// Main tests the download speeds of different websites in asynchronus.
        /// It uses Tasks to run WebsiteDownload. 
        /// WebsiteDownload measure the download speed in milliseconds. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
        //    Task.WaitAll(
        //        Task.Run(() => WebsiteDownload("https://www.google.com/")),
        //        Task.Run(() => WebsiteDownload("https://www.microsoft.com/")),
        //        Task.Run(() => WebsiteDownload("https://www.yahoo.com/")),
        //        Task.Run(() => WebsiteDownload("http://www.bing.com/")),
        //        Task.Run(() => WebsiteDownload("https://www.facebook.com/")),
        //        Task.Run(() => WebsiteDownload("https://www.espn.com")),
        //        Task.Run(() => WebsiteDownload("https://www.pinterest.com/")),
        //        Task.Run(() => WebsiteDownload("https://collaborateworship.com/reverb/"))
        //        );

        //    Console.Write("Finished thread.");
        //    Console.ReadKey();
        //}

        //static void WebsiteDownload(string website)
        //{
        //    WebClient client = new WebClient();

        //    client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

        //    Stopwatch sw = new Stopwatch();

        //    sw.Start();

        //    Stream newWebsite = client.OpenRead(@website);
        //    StreamReader reader = new StreamReader(newWebsite);
        //    string result = reader.ReadToEnd();

        //    sw.Stop();

        //    Console.WriteLine("Time elapsed: " + website + ": {0} millseconds.", sw.ElapsedMilliseconds);
        }
    }
}