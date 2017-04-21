using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDisposableCodingExerciseWeek14;
namespace IDisposableCodingExerciseWeek14Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Runs the Main method from the Program class. 
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            Program run = new Program();

            run.Main();
        }
    }
}
