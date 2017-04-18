using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDisposableExercise;

namespace IDisposableExerciseTests
{
    /// <summary>
    /// This class contains all tests for the <see cref="Student"/> class.
    /// </summary>
    [TestClass]
    public class StudentTests
    {
        /// <summary>
        /// This method checks to see if Dispose() is inplemented correctly in the derived class.
        /// </summary>
        [TestMethod]
        public void StudentDisposeTest()
        {
            Student Maria = new Student();
            Maria.Name = "Maria";
            Maria.Grade = "12";
            Maria.Dispose();
            Assert.AreEqual(true, Maria.disposed);
        }
    }
}
