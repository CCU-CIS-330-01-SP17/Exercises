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
    public class AssociationTests
    {
        [TestMethod]
        public void Can_Create_Association()
        {
            var association = new Association("Association Name", "555-555-5555", DateTime.Now, 7.00m, DateTime.Now.AddMonths(1));
            Assert.IsInstanceOfType(association, typeof(Association));
        }

        [TestMethod]
        public void Can_Read_Write_Properties()
        {
            DateTime meetTime = DateTime.Now.AddMonths(1).AddYears(2);
            var association = new Association("Association Name", "555-555-5555", DateTime.Now, 7.00m, DateTime.Now);
            association.NextMeeting = meetTime;
            Assert.AreEqual(7.00m, association.MonthlyDues);
            Assert.AreEqual(meetTime, association.NextMeeting);
        }

        [TestMethod]
        public void Can_Use_As_Organization()
        {
            var association = new Association("Association Name", "555-555-5555", DateTime.Now, 7.00m, DateTime.Now.AddMonths(1));
            Assert.IsInstanceOfType(association, typeof(Organization));
        }

        [TestMethod]
        public void Can_Use_As_Contact()
        {
            var association = new Association("Association Name", "555-555-5555", DateTime.Now, 7.00m, DateTime.Now.AddMonths(1));
            Assert.IsInstanceOfType(association, typeof(Contact));
        }
    }
}
