using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Week7Threading
{
    /// <summary>
    /// This class contains the Main method and all associated code.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This method asks the user for a number, then prints out a list of prime numbers up to the given number.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool running = true;
            Console.WriteLine("This program creates two lists of prime numbers up to a user specified number");
            Console.WriteLine("using both parallel and sequential for loops");
            while (running)
            {
                Console.WriteLine("User number:");
                try
                {
                    int givenNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("All prime numbers up to " + givenNumber + " parallel:");
                    Stopwatch parallelStopwatch = new Stopwatch();
                    parallelStopwatch.Start();
                    // This statement makes use of the parallel foreach loop.
                    foreach (int num in new PrimeCalculator().CalculatePrimesOfNumberFast(givenNumber))
                    {
                        Console.WriteLine(num);
                    }
                    parallelStopwatch.Stop();
                    Console.WriteLine("All prime numbers up to " + givenNumber + " sequential:");
                    Stopwatch sequentialStopwatch = new Stopwatch();
                    sequentialStopwatch.Start();
                    //This statement simply uses the sequential foreach loop.
                    foreach (int num in new PrimeCalculator().CalculatePrimesOfNumberSlow(givenNumber))
                    {
                        Console.WriteLine(num);
                    }
                    sequentialStopwatch.Stop();
                    Console.WriteLine("Parallel elapsed time: " + parallelStopwatch.Elapsed.TotalSeconds + " seconds");
                    Console.WriteLine("Sequential elapsed time: " + sequentialStopwatch.Elapsed.TotalSeconds + " seconds");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid whole number");
                }
            }
        }
    }
}
