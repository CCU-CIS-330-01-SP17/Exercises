using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7Threading;

namespace Week7ThreadingTests
{
    /// <summary>
    /// This class contains tests for the <see cref="PrimeCalculator"/> class 
    /// </summary>
    [TestClass]
    public class CalculatePrimesTests
    {
        [TestMethod]
        public void IsPrimeDisplayCorrectPrimeNumbers()
        {
            int[] primeNumbers =
            {
                2,
                3,
                5,
                7,
                60013,
                1009,
                97
            };
            foreach(int number in primeNumbers)
            {
                bool isPrime = new PrimeCalculator().IsPrime(number);
                Console.WriteLine(number + " " + isPrime);
                Assert.AreEqual(true, isPrime);
            }
        }

        [TestMethod]
        public void IsPrimeDisplayCorrectCompositeNumbers()
        {
            int[] compositeNumbers =
            {
                1,
                99,
                72,
                4,
                6,
                600014,
                600015
            };
            foreach(int number in compositeNumbers)
            {
                bool notPrime = new PrimeCalculator().IsPrime(number);
                Console.WriteLine(number + " " + notPrime);
                Assert.AreEqual(false, notPrime);
            }
        }
    }
}
