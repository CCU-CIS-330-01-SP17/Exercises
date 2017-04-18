using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDisposableExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableExercise.Tests
{
    /// <summary>
    /// This class contains all test methods for the <see cref="Person"/> class.
    /// </summary>
    [TestClass()]
    public class PersonTests
    {
        /// <summary>
        /// This method checks to see if Dispose() is implemented correctly in the base class.
        /// </summary>
        [TestMethod()]
        public void PersonDisposeTest()
        {
            Person Bob = new Person();
            Bob.Name = "Bob";
            Bob.Dispose();
            Assert.AreEqual(true, Bob.disposed);
        }
    }
}