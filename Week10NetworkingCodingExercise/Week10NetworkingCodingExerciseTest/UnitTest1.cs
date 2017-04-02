using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using StreamsIONetworking;

namespace Week10NetworkingCodingExerciseTest
{
    /// <summary>
    /// Tests the code that is in the Program class.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //use WebClient to pull information down and test against
            WebClient testClient = new WebClient();

            string response = testClient.DownloadString(@"http://localhost:8001/?x=4&y=6");
            
            Assert.AreEqual(@"<HTML><BODY> The asnwer is: 10 </BODY></HTML>", response);
        }
    }
}
