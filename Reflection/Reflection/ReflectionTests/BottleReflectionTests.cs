using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection;

namespace ReflectionTests
{
    [TestClass]
    public class BottleReflectionTests
    {
        [TestMethod]
        public void Bottle_Can_Be_Constructed()
        {
            Bottle bottle = Activator.CreateInstance(typeof(Bottle)) as Bottle;
            Assert.IsInstanceOfType(bottle, typeof(Bottle));
        }

        [TestMethod]
        public void Bottle_Can_Write_IsInked()
        {
            var propertyInfo = typeof(Bottle).GetProperty("IsFull");
            Assert.IsTrue(propertyInfo.CanWrite);
        }

        [TestMethod]
        public void Bottle_Can_Read_IsInked()
        {
            var propertyInfo = typeof(Bottle).GetProperty("IsFull");
            Assert.IsTrue(propertyInfo.CanRead);
        }

        [TestMethod]
        public void Bottle_Can_Read_Message()
        {
            var propertyInfo = typeof(Bottle).GetProperty("Liquid");
            Assert.IsTrue(propertyInfo.CanRead);
        }

        [TestMethod]
        public void Bottle_Can_Write_Message()
        {
            var propertyInfo = typeof(Bottle).GetProperty("Liquid");
            Assert.IsTrue(propertyInfo.CanWrite);
        }

        [TestMethod]
        public void Bottle_Can_Fill()
        {
            Bottle bottle = Activator.CreateInstance(typeof(Bottle)) as Bottle;
            MethodInfo bottleMessage = bottle.GetType().GetMethods().Single(m => m.Name == "Fill");
            var bottleMessageResult = bottleMessage.Invoke(bottle, null);
            Assert.AreEqual("You have filled the bottle with !", bottleMessageResult);
        }
    }
}
