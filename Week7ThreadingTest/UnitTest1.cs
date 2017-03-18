using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7Threading;
using System.Collections.Generic;

namespace Week7ThreadingTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// TestMethod1 sends a list of urls to Threading.RunProgram to run the download speeds of each website.
        /// After Threading.RunProgram is complete it will return "true" upon completion. 
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            var urlList = new List<string>
            {
                "https://www.google.com/",
                "https://www.microsoft.com/",
                "https://www.yahoo.com/",
                "http://www.bing.com/",
                //"https://www.facebook.com/",
                //"https://www.espn.com",
                //"https://www.pinterest.com/",
                //"https://collaborateworship.com/reverb/"
            };

            var test = Threading.RunProgram(urlList);
            bool result = test.Result;
            Assert.IsTrue(result);
        }
    }
}
