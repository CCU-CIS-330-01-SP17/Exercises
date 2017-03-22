using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetworkingCodingExcersise
{
    /// <summary>
    /// This program adds two user specified numbers utilizing a web client through a user specified port number.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This represents the main logic of the program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int portNumber = DisplayMessageValidateInput();
            ListenAsync(portNumber);
            Console.WriteLine($"Server running on port {portNumber}. Press Enter to stop.");
            Console.ReadLine();
        }

        /// <summary>
        /// This method prompts the user to enter a port number, validates it, then returns it as an int..
        /// </summary>
        public static int DisplayMessageValidateInput()
        {
            int ConsoleValidatedInput = 0;
            while (true)
            {
                Console.WriteLine("Enter a Port number to listen on:");
                try
                {
                    int userInputPortNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Port number Accepted");
                    ConsoleValidatedInput = userInputPortNumber;
                    return ConsoleValidatedInput;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid port number detected. Please re-try.");
                }
            }
        }

        /// <summary>
        /// This method listens for a http request using the portNumber parameter.
        /// </summary>
        /// <param name="portNumber"></param>
        public async static void ListenAsync(int portNumber)
        {
            UriBuilder uri = new UriBuilder("http", "localhost", portNumber);
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
        /// This method is used to process incoming requests.
        /// </summary>
        /// <param name="context"></param>
        public static void ProcessRequestAsync(HttpListenerContext context)
        {
            string x = context.Request.QueryString["x"];
            string y = context.Request.QueryString["y"];
            if (!string.IsNullOrWhiteSpace(x) && !string.IsNullOrWhiteSpace(y))
            {
                try
                {
                    if (Convert.ToInt64(x) + Convert.ToInt64(y) > 2147483647)
                    {
                        using (StreamWriter writer = new StreamWriter(context.Response.OutputStream))
                        {
                            writer.Write("Sum greater than the max value of int32; try again!");
                            context.Response.StatusCode = (int)HttpStatusCode.OK;
                        }
                    }
                    int sum = Convert.ToInt32(x) + Convert.ToInt32(y);
                    string result = Convert.ToString(sum);
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    using (StreamWriter writer = new StreamWriter(context.Response.OutputStream))
                    {
                        writer.Write(result);
                    }
                }
                catch (FormatException)
                {
                    using (StreamWriter writer = new StreamWriter(context.Response.OutputStream))
                    {
                        writer.Write("Make sure your query string arguments are valid integers and try again!");
                    }
                }
                catch (OverflowException)
                {
                    using (StreamWriter writer = new StreamWriter(context.Response.OutputStream))
                    {
                        writer.Write("Make sure each one of your query string arguments arent greater than 2147483647; try again!");
                    }
                }
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.OutputStream.Close();
            }
        }
    }
}