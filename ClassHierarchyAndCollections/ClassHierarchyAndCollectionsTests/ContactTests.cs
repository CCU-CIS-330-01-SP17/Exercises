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
    public class ContactTests
    {
        [TestMethod]
        public void Can_Create_Contact()
        {
            var organization = new ClassHierarchyAndCollections.Contact("Contact Name", "555-555-5555");
            Assert.IsInstanceOfType(organization, typeof(Contact));
        }

        [TestMethod]
        public void Can_Read_Write_Properties()
        {
            var organization = new Contact("Contact Name", "555-555-5555");
            Assert.AreEqual("Contact Name", organization.Name);
            Assert.AreEqual("555-555-5555", organization.PrimaryPhoneNumber);
        }
    }
}
