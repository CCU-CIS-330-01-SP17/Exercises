using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StreamsIONetworking
{
    /// <summary>
    /// Program runs calculations for querty string.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Calls the methods that do the calculations.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            HttpListenerDemo();
        }
        /// <summary>
        /// Runs localhost based on user specified port number.
        /// </summary>
        public static void HttpListenerDemo()
        {
            Console.WriteLine("Please enter the port number you want to use:");
            string portNum = Console.ReadLine();
            int portNumber = Convert.ToInt32(portNum);
            UriBuilder uri = new UriBuilder("http", "localhost", portNumber);

            ListenAsync(uri);

            Console.WriteLine($"Server running on port {portNumber}. Press Enter to stop.");
            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">URI that is passed into so that HttpListener knows where to listen.</param>
        async static void ListenAsync(UriBuilder url)
        {
            UriBuilder uri = url;

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(uri.ToString());
            listener.Start();

            while (true)
            {
                try
                {
                    var context = await listener.GetContextAsync();
                    await Task.Run(() => ProcessRequestAsync(context));
                }
                catch (HttpListenerException) { break; }
                catch (InvalidOperationException) { break; }
            }

            listener.Stop();
        }

        /// <summary>
        /// Calculates values from the query string. 
        /// </summary>
        /// <param name="context"></param>
        private static void ProcessRequestAsync(HttpListenerContext context)
        {
            string x = context.Request.QueryString["x"];
            string y = context.Request.QueryString["y"];

            int queryValueX = 0;
            int queryValueY = 0;
         
            if (int.TryParse(x, out queryValueX) && int.TryParse(y, out queryValueY))
            {
                int result = queryValueX + queryValueY;

                context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(result.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.OK;

                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                string responseString = "<HTML><BODY> The asnwer is: " + result + " </BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                // You must close the output stream.
                output.Close();
            }
            else
            {
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                string responseString = "<HTML><BODY>Please enter an integer value. </BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                // You must close the output stream.
                output.Close();

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.OutputStream.Close();
            }
        }
    }
}