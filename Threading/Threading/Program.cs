using System;
using System.Diagnostics;
using System.Linq;

namespace Threading
{
    /// <summary>
    /// This prints the time taken to calculate primes in parallel.
    /// </summary>
    class Program
    {
        /// <summary>
        /// This times a prime calculation set and prints the elapsed duration to the console.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            watch.Start();
            var x = PrimeCalculator.CalculatePrimesAsync(11);
            watch.Stop();
            Console.WriteLine("Calculation Time: " + watch.Elapsed);
        }
    }
}
