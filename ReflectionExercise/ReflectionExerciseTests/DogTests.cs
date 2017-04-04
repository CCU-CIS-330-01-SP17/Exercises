using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExercise.Tests
{
    /// <summary>
    /// This class contains tests for the <see cref="Dog"/> class.
    /// </summary>
    [TestClass()]
    public class DogTests
    {
        [TestMethod()]
        public void ConstructDog()
        {
            Dog d = Activator.CreateInstance(typeof(Dog)) as Dog;
        }

        [TestMethod()]
        public void ReadWriteDogProperties()
        {
            Dog d = new Dog();
            PropertyInfo dogNumLegs = d.GetType().GetProperty("NumberOfLegs");
            dogNumLegs.SetValue(d, 3, null);
            Assert.AreEqual(3, dogNumLegs.GetValue(d));
        }

        [TestMethod()]
        public void InvokeDogMethod()
        {
            Dog d = new Dog();
            MethodInfo barkMethod = d.GetType().GetMethod("Bark");
            barkMethod.Invoke(d, new object[] { });
        }
    }
}