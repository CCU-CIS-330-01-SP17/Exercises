using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace NetworkingCodingExcersiseTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CorrectServerResponse()
        {
            string searchUrl = "http://localhost:8001/?x=16&y=55";
            using (WebClient client = new WebClient())
            {
                int serverResponse = Convert.ToInt32(client.DownloadString(searchUrl));
                Assert.AreEqual(71, serverResponse);
            }
        }
    }
}
