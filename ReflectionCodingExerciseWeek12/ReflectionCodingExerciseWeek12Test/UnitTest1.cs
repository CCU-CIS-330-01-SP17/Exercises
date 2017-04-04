using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionCodingExerciseWeek12;

namespace ReflectionCodingExerciseWeek12Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CarConstructionTest()
        {
            Car toyota = new Car("Camry", 5);

            bool testTypeOf = false;

            if (toyota.GetType() == typeof(Car))
            {
                testTypeOf = true;
            }
            else
            {
                testTypeOf = false;
            }

            Assert.IsTrue(testTypeOf);
        }

        [TestMethod]
        public void CarPropertyTest()
        {
            Car toyota = new Car("Camry", 5);
            var carType = toyota.GetType();

            int validate = toyota.GetPropertyInformation(carType);
            bool canReadCanWrite = false;

            if (validate == 2)
            {
                canReadCanWrite = true;
            }
            else
            {
                canReadCanWrite = false;
            }

            Assert.IsTrue(canReadCanWrite);
        }

        [TestMethod]
        public void CarMethodInvokeTest()
        {
            Car toyota = new Car("Camry", 5);

            MethodInfo driveMethod = toyota.GetType().GetMethod("Drive", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int), typeof(string) }, null);
            driveMethod.Invoke(toyota, new object[] { 35, "MPH" });

            //MethodInfo driveMethod = toyota.GetType().GetMethod("Drive", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int), typeof(string) }, null);
            //driveMethod.Invoke(toyota, null);
        }
    }
}

