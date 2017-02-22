using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class IndividualTests
    {
        [TestMethod]
        public void Can_Create_Organization()
        {
            var individual = new Individual("Bob", "911", 7, "Apache Helicopter");
            Assert.IsInstanceOfType(individual, typeof(Individual));
        }

        [TestMethod]
        public void Can_Read_Write_Properties()
        {
            var individual = new Individual("Bob", "911", 7, "Apache Helicopter");
            Assert.AreEqual(7, individual.Age);
            Assert.AreEqual("Apache Helicopter", individual.Gender);
        }

        [TestMethod]
        public void Can_Use_As_Contact()
        {
            var individual = new Individual("Bob", "911", 7, "Apache Helicopter");
            Assert.IsInstanceOfType(individual, typeof(Contact));
        }
    }
}
