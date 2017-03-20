using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetworkingTests
{
    [TestClass]
    public class HttpServerTests
    {
        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void Request_Without_Query_Strings_Returns_Bad_Request()
        {
            var uri = new UriBuilder("http", "localhost", 84);
            var webClient = new WebClient();
            webClient.DownloadString(uri.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void Request_With_Malformed_Query_Strings_Returns_Bad_Request()
        {
            var uri = new UriBuilder("http", "localhost", 84);
            var webClient = new WebClient
            {
                QueryString =
                {
                    ["x"] = "apple",
                    ["y"] = "8"
                }
            };
            webClient.DownloadString(uri.ToString());
        }

        [TestMethod]
        public void Valid_Query_Strings_Are_Correctly_Added()
        {
            var uri = new UriBuilder("http", "localhost", 84);
            var webClient = new WebClient
            {
                QueryString =
                {
                    ["x"] = "9",
                    ["y"] = "8"
                }
            };
            string responseHtml = webClient.DownloadString(uri.ToString());
            Assert.AreEqual($"<HTML><BODY> 17 </BODY></HTML>", responseHtml);
        }

    }
}
