using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    /// <summary>
    /// Defines tests for the <see cref="Association"/> class.
    /// </summary>
    [TestClass]
    public class AssociationTests
    {
        /// <summary>
        /// This method tests to see if an instance of the "Association" class can be created.
        /// </summary>
        [TestMethod]
        public void CreateInstanceAssociationClass()
        {
            Association sampleAssociation = new Association();
            Assert.IsNotNull(sampleAssociation);
        }

        /// <summary>
        /// This method checks that the "Association" class derives from the "Organization" Class
        /// </summary>
        [TestMethod]
        public void DerivesCorrectlyAssociationClass()
        {
            Association sampleAssociation = new Association();
            Assert.IsInstanceOfType(sampleAssociation, typeof(Organization));
        }

        /// <summary>
        /// This method checks that each property of the "Individual" class can be written and read.
        /// </summary>
        [TestMethod]
        public void ReadWritePropertiesAssociationClass()
        {
            var sampleAssociation = new Association();
            sampleAssociation.Acronym= "CDC";
            sampleAssociation.AnnualDues = 150.55m;
            Assert.AreEqual(sampleAssociation.Acronym,"CDC");
            Assert.AreEqual(sampleAssociation.AnnualDues, 150.55m);
        }
    }
}

