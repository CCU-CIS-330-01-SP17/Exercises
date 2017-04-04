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
    /// This class contains tests for the <see cref="Cat"/> class.
    /// </summary>
    [TestClass()]
    public class CatTests
    {
        [TestMethod()]
        public void ConstructCat()
        {
            Cat c = Activator.CreateInstance(typeof(Cat)) as Cat;
        }

        [TestMethod()]
        public void ReadWriteCatProperties()
        {
            Cat c = new Cat();
            PropertyInfo catNumLegs = c.GetType().GetProperty("NumberOfLegs");
            catNumLegs.SetValue(c, 4, null);
            Assert.AreEqual(4,catNumLegs.GetValue(c));
        }

        [TestMethod()]
        public void InvokeCatMethod()
        {
            Cat c = new Cat();
            MethodInfo meowMethod = c.GetType().GetMethod("Meow");
            meowMethod.Invoke(c,new object[] { });
        }
    }
}