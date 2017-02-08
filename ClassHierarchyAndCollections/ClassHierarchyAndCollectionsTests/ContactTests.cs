using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    /// <summary>
    /// Defines tests for the <see cref="Contact"/> class.
    /// </summary>
    [TestClass]
    public class ContactTests
    {
        /// <summary>
        /// This method tests to see if an instance of the "Contact" class can be created.
        /// </summary>
        [TestMethod]
        public void CreateInstanceContactClass()
        {
            Contact sampleContact = new Contact();
            Assert.IsNotNull(sampleContact);
        }

        /// <summary>
        /// This method checks that the "Contact" class derives from the "Contact" class.
        /// </summary>
        [TestMethod]
        public void DerivesCorrectlyContactClass()
        {
            Contact sampleContact = new Contact();
            Assert.IsInstanceOfType(sampleContact, typeof(Contact));
        }

        /// <summary>
        /// This method tests that each property of the "Contact" class can be written and read.
        /// </summary>
        [TestMethod]
        public void ReadWritePropertiesContactClass()
        {
            var sampleContact = new Contact();
            sampleContact.DateAdded = new DateTime(2008, 12, 6);
            sampleContact.DisplayName = "Test Organization";
            Assert.AreEqual(sampleContact.DateAdded, new DateTime(2008, 12, 6));
            Assert.AreEqual(sampleContact.DisplayName, "Test Organization");
        }
    }
}
