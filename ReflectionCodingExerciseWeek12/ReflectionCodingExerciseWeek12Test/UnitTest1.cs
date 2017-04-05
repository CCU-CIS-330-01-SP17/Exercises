using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionCodingExerciseWeek12;

namespace ReflectionCodingExerciseWeek12Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests to see if an instance of Car was constructed.
        /// </summary>
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
        /// <summary>
        /// Tests to see if the parameters are read and write. 
        /// If it passes, validate is equal to 2 because both properties are read and write.
        /// </summary>
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
        /// <summary>
        /// Tests to see if the Drive method can be invoked.
        /// </summary>
        [TestMethod]
        public void CarMethodInvokeTest()
        {
            Car toyota = new Car("Camry", 5);

            MethodInfo driveMethod = toyota.GetType().GetMethod("Drive", BindingFlags.Public | BindingFlags.Instance);
            driveMethod.Invoke(toyota, null);
        }
        /// <summary>
        /// Tests to see if an instance of AirPlane was constructed.
        /// </summary>
        [TestMethod]
        public void AirPlaneConstructionTest()
        {
            AirPlane boeing = new AirPlane("737", 290);

            bool testTypeOf = false;

            if (boeing.GetType() == typeof(AirPlane))
            {
                testTypeOf = true;
            }
            else
            {
                testTypeOf = false;
            }

            Assert.IsTrue(testTypeOf);
        }
        /// <summary>
        /// Tests to see if the parameters are read and write. 
        /// If it passes, validate is equal to 2 because both properties are read and write.
        /// </summary>
        [TestMethod]
        public void AirPlanePropertyTest()
        {
            AirPlane boeing = new AirPlane("737", 290);
            var planeType = boeing.GetType();

            int validate = boeing.GetPropertyInformation(planeType);
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
        /// <summary>
        /// Tests to see if the Fly method can be invoked.
        /// </summary>
        [TestMethod]
        public void AirPlaneMethodInvokeTest()
        {
            AirPlane boeing = new AirPlane("737", 290);

            MethodInfo flyMethod = boeing.GetType().GetMethod("Fly", BindingFlags.Public | BindingFlags.Instance);
            flyMethod.Invoke(boeing, null);
        }
    }
}

