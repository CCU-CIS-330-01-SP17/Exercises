using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading
{
    /// <summary>
    /// This class assists in the calculation of prime numbers.
    /// </summary>
    public static class PrimeCalculator
    {
        // The CheckPrime methods below were taken from StackOverflow user 0x90 and modified. 
        /// <summary>
        /// This method verifies if a number is prime asynchronously.
        /// </summary>
        /// <param name="number">This is the number to be prime checked.</param>
        /// <returns>This returns true if the number is prime, otherwise it returns false.</returns>
        public static async Task<bool> CheckPrimeAsync(int number)
        {
            //One is not a prime number.
            if (number == 1)
            {
                return false;
            }
            //Two is a prime number.
            else if (number == 2)
            {
                return true;
            }
            //This loops through all integers between 2 and the square root of the number.
            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); i++)
            {
                //This is to check if the number is divisible by the current possible factor.
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
       
        /// <summary>
        /// This calculates all primes asynchronously up to a given amount.
        /// </summary>
        /// <param name="max">This is the highest number to check for primes.</param>
        /// <returns>This returns a list of prime numbers.</returns>
        public static List<int> CalculatePrimesAsync(int max)
        {
            var primes = new List<int>();
            var tasks = new Task<bool>[max];

            //Create threads for each prime number check.
            //The [i-1]s below are because the array is 0-based while the loops are 1-based.
            for (int i = 1; i <= max; i++)
            {
                tasks[i - 1] = CheckPrimeAsync(i);
            }

            //Wait for all tasks to complete.
            Task.WaitAll(tasks);

            for (int i = 1; i <= max; i++)
            {
                //If a number check comes back as true, it's position in the array is prime. 
                if (tasks[i - 1].Result == true)
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
    }
}
