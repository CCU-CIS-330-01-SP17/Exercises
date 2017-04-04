using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection;

namespace ReflectionTests
{
    [TestClass]
    public class StampReflectionTests
    {
        [TestMethod]
        public void Stamp_Can_Be_Constructed()
        {
            Stamp stamp = Activator.CreateInstance(typeof(Stamp)) as Stamp;
            Assert.IsInstanceOfType(stamp, typeof(Stamp));
        }

        [TestMethod]
        public void Stamp_Can_Write_IsInked()
        {
            var propertyInfo = typeof(Stamp).GetProperty("IsInked");
            Assert.IsTrue(propertyInfo.CanWrite);
        }

        [TestMethod]
        public void Stamp_Can_Read_IsInked()
        {
            var propertyInfo = typeof(Stamp).GetProperty("IsInked");
            Assert.IsTrue(propertyInfo.CanRead);
        }

        [TestMethod]
        public void Stamp_Can_Read_Message()
        {
            var propertyInfo = typeof(Stamp).GetProperty("Message");
            Assert.IsTrue(propertyInfo.CanRead);
        }

        [TestMethod]
        public void Stamp_Can_Write_Message()
        {
            var propertyInfo = typeof(Stamp).GetProperty("Message");
            Assert.IsTrue(propertyInfo.CanWrite);
        }

        [TestMethod]
        public void Stamp_Can_Stamp_Message()
        {
            Stamp stamp = Activator.CreateInstance(typeof(Stamp)) as Stamp;
            MethodInfo stampMessage = stamp.GetType().GetMethods().Single(m => m.Name == "StampMessage");
            var stampMessageResult = stampMessage.Invoke(stamp, null);
            Assert.AreEqual("", stampMessageResult);
        }

    }
}
