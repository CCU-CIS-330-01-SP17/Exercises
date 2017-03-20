using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    /// <summary>
    /// Helps create and handle a small webserver.
    /// </summary>
    public static class HttpServer
    {
        /// <summary>
        /// Creates a background HttpListener process to act as a small webserver.
        /// </summary>
        /// <param name="port">The port on which the webserver should listen.</param>
        public static async void ListenAsync(int port)
        {
            var uri = new UriBuilder("http", "localhost", port);

            var listener = new HttpListener();
            listener.Prefixes.Add(uri.ToString());
            listener.Start();

            while (true)
            {
                try
                {
                    var context = await listener.GetContextAsync();
                    string responseHtml = await Task.Run(() => GenerateResponse(context));
                    WriteBuffer(context, responseHtml);
                }
                catch (HttpListenerException httpListenerException)
                {
                    Console.WriteLine(httpListenerException);
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    Console.WriteLine(invalidOperationException);
                }
            }
        }

        /// <summary>
        /// Takes a HttpListenerContext and creates an HTML string response.
        /// </summary>
        /// <param name="httpListenerContext">The context of the most recent connection.</param>
        /// <returns>Returns a string containing HTML to send back to the requester.</returns>
        private static string GenerateResponse(HttpListenerContext httpListenerContext)
        {
            var request = httpListenerContext.Request;
            var response = httpListenerContext.Response;

            int firstNumber;
            int secondNumber;

            //Check if both query strings are present.
            if (string.IsNullOrWhiteSpace(request.QueryString["x"]) ||
                string.IsNullOrWhiteSpace(request.QueryString["y"]))
            {
                httpListenerContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return "<HTML><BODY> Missing Arguments. </BODY></HTML>";
            }

            try
            {
                firstNumber = Convert.ToInt32(request.QueryString["x"]);
                secondNumber = Convert.ToInt32(request.QueryString["y"]);
            }
            catch (FormatException)
            {
                //Arguments are not valid, Bad Request.
                httpListenerContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return "<HTML><BODY> Invalid Arguments. </BODY></HTML>";
            }

            // Construct a response.
            httpListenerContext.Response.StatusCode = (int) HttpStatusCode.OK;
            return $"<HTML><BODY> {firstNumber + secondNumber} </BODY></HTML>";
        }

        /// <summary>
        /// Writes a response to a httpListenerContext's buffer.
        /// </summary>
        /// <param name="httpListenerContext">The context which will be written to.</param>
        /// <param name="responseHtml">The html which will be written.</param>
        private static void WriteBuffer(HttpListenerContext httpListenerContext, string responseHtml)
        {
            var buffer = Encoding.UTF8.GetBytes(responseHtml);
            httpListenerContext.Response.ContentLength64 = buffer.Length;
            var output = httpListenerContext.Response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
        }
    }
}
