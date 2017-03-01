using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Week7Threading
{
    /// <summary>
    /// This class contains the methods and associated code used to calculate prime numbers.
    /// </summary>
    public class PrimeCalculator
    {
        /// <summary>
        /// This method calculates if a number is prime using a sequential for loop.
        /// </summary>
        /// <param name="userNumber"></param>
        /// <returns></returns>
        public bool IsPrime(int number)
        {
            if (number == 1)
            {
                return false;
            }
            else if (number == 2)
            {
                return true;
            }
            else if (number % 2 == 0)
            {
                return false;
            }
            int i;
            for (i = 3; i <= Math.Sqrt(number); i+=2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// This method returns a list of all prime numbers up to a specified number using the parallel foreach statement.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<int> CalculatePrimesOfNumberFast(int number)
        {
            List<int> primesofnumber = new List<int>();
            IEnumerable<int> numberstoevaluate = Enumerable.Range(2, number - 1);
            Parallel.ForEach(numberstoevaluate, (num) =>
                {
                    if (IsPrime(num))
                    {
                        lock (this)
                        {
                            primesofnumber.Add(num);
                        }
                    }
                });
            return primesofnumber;
        }

        /// <summary>
        /// This method returns a list of all prime numbers up to a specified number using the sequential foreach statement.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<int> CalculatePrimesOfNumberSlow(int number)
        {
            List<int> primesofnumber = new List<int>();
            IEnumerable<int> numberstoevaluate = Enumerable.Range(2, number -1);
            foreach (int num in numberstoevaluate)
            {
                if (IsPrime(num))
                {
                    primesofnumber.Add(num);
                }
            }
            return primesofnumber;
        }
    }
}
