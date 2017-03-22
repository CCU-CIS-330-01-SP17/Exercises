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
            //UriDemo();
            //HttpListenerDemo();
        }

        /// <summary>
        /// For understanding how to use query strings.
        /// </summary>
        private static void UriDemo()
        {
            Console.WriteLine("Uri:");
            Uri link = new Uri("https://msdn.microsoft.com/en-us/library/system.uri(v=vs.110).aspx?query=abc");
            Console.WriteLine($"Scheme: {link.Scheme}");
            Console.WriteLine($"Port: {link.Port}");
            Console.WriteLine($"Host: {link.Host}");
            Console.WriteLine($"PathAndQuery: {link.PathAndQuery}");

            Console.WriteLine();
            Console.WriteLine("UriBuilder:");
            UriBuilder linkBuilder = new UriBuilder("http://localhost:8001?x=1&y=2");
            Console.WriteLine($"Scheme: {linkBuilder.Scheme}");
            Console.WriteLine($"Port: {linkBuilder.Port}");
            Console.WriteLine($"Host: {linkBuilder.Host}");
            Console.WriteLine($"Path: {linkBuilder.Path}");
            Console.WriteLine($"Query: {linkBuilder.Query}");

            Console.ReadKey();
        }

        /// <summary>
        /// Runs localhost based on user specified port number.
        /// </summary>
        private static void HttpListenerDemo()
        {
            Console.WriteLine("Please enter the port number you want to use:");
            string portNum = Console.ReadLine();
            int portNumber = Convert.ToInt32(portNum);
            UriBuilder uri = new UriBuilder("http", "localhost", portNumber);

            Console.WriteLine($"Query: {uri.Query}");

            if (uri.Query != "")
            {
                ListenAsync(uri);
            }
            else
            {
                // Create a listener.
                using (HttpListener listener = new HttpListener())
                {
                    listener.Prefixes.Add(uri.ToString());
                    listener.Start();

                    Console.WriteLine("Listening...");

                    // Note: The GetContext method blocks while waiting for a request. 
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;

                    // Obtain a response object.
                    HttpListenerResponse response = context.Response;

                    // Construct a response.
                    string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                    // Get a response stream and write the response to it.
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);

                    // You must close the output stream.
                    output.Close();
                    listener.Stop();
                }
            }

            Console.WriteLine($"Server running on port {portNumber}. Press Enter to stop.");
            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
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

            if (!string.IsNullOrWhiteSpace(x) && !string.IsNullOrWhiteSpace(y))
            {
                string result = x + y;

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

                Console.WriteLine(result);

            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.OutputStream.Close();
            }
        }
    }
}