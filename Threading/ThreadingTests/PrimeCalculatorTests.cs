using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Threading;

namespace ThreadingTests
{
    [TestClass]
    public class PrimeCalculatorTests
    {
        [TestMethod]
        public void Number_14951_Is_Prime()
        {
            Assert.IsTrue(PrimeCalculator.CheckPrimeAsync(14951).Result);
        }

        [TestMethod]
        public void Number_14952_Is_Not_Prime()
        {
            Assert.IsFalse(PrimeCalculator.CheckPrimeAsync(14952).Result);
        }

        [TestMethod]
        public void Number_One_Is_Not_Prime()
        {
            Assert.IsFalse(PrimeCalculator.CheckPrimeAsync(1).Result);
        }

        [TestMethod]
        public void Primes_To_Eleven_Are_Correct()
        {
            var primes = PrimeCalculator.CalculatePrimesAsync(11);
            Assert.IsTrue(primes.Contains(2));
            Assert.IsTrue(primes.Contains(3));
            Assert.IsTrue(primes.Contains(5));
            Assert.IsTrue(primes.Contains(7));
            Assert.IsTrue(primes.Contains(11));
            Assert.AreEqual(primes.Count, 5);
        }
    }
}
