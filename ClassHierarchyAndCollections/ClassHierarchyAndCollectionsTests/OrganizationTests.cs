using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
{
    /// <summary>
    /// Tests for ClassHierarchyAndCollections.Organization
    /// </summary>
    [TestClass]
    public class OrganizationTests
    {
        [TestMethod]
        public void Can_Create_Organization()
        {
            var organization = new Organization("Organization Name", "555-555-5555", DateTime.Now);
            Assert.IsInstanceOfType(organization, typeof(Organization));
        }

        [TestMethod]
        public void Can_Read_Write_Properties()
        {
            var testTime = DateTime.Now;
            var organization = new Organization("Organization Name", "555-555-5555", testTime);
            organization.Members.Add(new Individual("Bob", "911", 7, "Apache Helicopter"));
            Assert.AreEqual(testTime, organization.FoundingDate);
            Assert.AreEqual(1, organization.Members.Count);
        }

        [TestMethod]
        public void Can_Use_As_Contact()
        {
            var organization = new Organization("Organization Name", "555-555-5555", DateTime.Now);
            Assert.IsInstanceOfType(organization, typeof(Contact));
        }
    }
}
