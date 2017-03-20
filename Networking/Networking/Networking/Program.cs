using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    /// <summary>
    /// Kicks off the networking process.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Sets up the webserver and waits for it.
        /// </summary>
        /// <param name="args">A list of arguments, containing the integer port number for the server to listen on.</param>
        static void Main(string[] args)
        {
            HttpServer.ListenAsync(Convert.ToInt32(args[0]));
            Console.WriteLine("Server Online. Press Enter to close.");
            Console.ReadLine();
        }
    }
}
