using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;

namespace Week10NetworkingCodingExerciseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UriBuilder uri = new UriBuilder("http", "lcoalhost", 8001);
            ListenAsync(uri);

            //use WebClient to pull information down and test against
            WebClient testClient = new WebClient();

            testClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream website = testClient.OpenRead(@"localhost:8001/");
            StreamReader reader = new StreamReader(website);
            string result = reader.ReadToEnd();

            Console.WriteLine(result);
        }
    }
}
