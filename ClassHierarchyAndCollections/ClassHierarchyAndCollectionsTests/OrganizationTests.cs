using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    /// <summary>
    /// Defines tests for the <see cref="Organization"/> class.
    /// </summary>
    [TestClass]
    public class OrganizationTests
    {
        /// <summary>
        /// This method tests to see if an instance of the "Organization" class can be created.
        /// </summary>
        [TestMethod]
        public void CreateInstanceOrganizationClass()
        {
            Organization sampleOrganization = new Organization();
            Assert.IsNotNull(sampleOrganization);
        }

        /// <summary>
        /// This method checks that the "Organization" class derives from the "Contact" Class
        /// </summary>
        [TestMethod]
        public void DerivesCorrectlyOrganizationClass()
        {
            Organization sampleOrganization = new Organization();
            Assert.IsInstanceOfType(sampleOrganization, typeof(Contact));
        }

        /// <summary>
        /// This method checks that each property of the "Organization" class can be written and read.
        /// </summary>
        [TestMethod]
        public void ReadWritePropertiesOrganizationsClass()
        {
            var sampleOrganization = new Organization();
            sampleOrganization.FormationDate = new DateTime(2015, 10, 9);
            sampleOrganization.DepartmentName = "Accounting";
            Assert.AreEqual(sampleOrganization.FormationDate, new DateTime(2015, 10, 9));
            Assert.AreEqual(sampleOrganization.DepartmentName, "Accounting");
        }
    }
}
