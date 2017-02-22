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
    public class BusinessTests
    {
        [TestMethod]
        public void Can_Create_Business()
        {
            var business = new Business("Business Name", "555-555-5555", DateTime.Now, new Individual("Natas", "666-666-6666", 9001, "Unknown"));
            Assert.IsInstanceOfType(business, typeof(Business));
        }

        [TestMethod]
        public void Can_Read_Write_Properties()
        {
            var newOwner = new Individual("Natas", "666-666-6666", 9001, "Unknown");
            var business = new Business("Business Name", "555-555-5555", DateTime.Now, new Individual("Tim", "111-111-1111", 3, "Male"));
            business.Employees.Add(new Individual("Grim R.", "444-444-4444", int.MaxValue, "Genderless"));
            business.Employees.Add(newOwner);
            business.ChiefExecutiveOfficer = newOwner;
            Assert.AreEqual(newOwner, business.ChiefExecutiveOfficer);
            Assert.AreEqual(3, business.Employees.Count);
        }

        [TestMethod]
        public void Can_Use_As_Organization()
        {
            var business = new Business("Business Name", "555-555-5555", DateTime.Now, new Individual("Natas", "666-666-6666", 9001, "Unknown"));
            Assert.IsInstanceOfType(business, typeof(Organization));
        }

        [TestMethod]
        public void Can_Use_As_Contact()
        {
            var business = new Business("Business Name", "555-555-5555", DateTime.Now, new Individual("Natas", "666-666-6666", 9001, "Unknown"));
            Assert.IsInstanceOfType(business, typeof(Contact));
        }
    }
}
