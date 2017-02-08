using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    /// <summary>
    /// Defines tests for the <see cref="Individual"/> class.
    /// </summary>
    [TestClass]
    public class IndividualTests
    {
        /// <summary>
        /// This method tests to see if an instance of the "Individual" class can be created.
        /// </summary>
        [TestMethod]
        public void CreateInstanceIndividualClass()
        {
            Individual sampleIndividual = new Individual();
            Assert.IsNotNull(sampleIndividual);
        }

        /// <summary>
        /// This method checks that the "Individual" class derives from the "Contact" Class
        /// </summary>
        [TestMethod]
        public void DerivesCorrectlyIndividualClass()
        {
            Individual sampleIndividual = new Individual();
            Assert.IsInstanceOfType(sampleIndividual, typeof(Contact));
        }

        /// <summary>
        /// This method checks that each property of the "Individual" class can be written and read.
        /// </summary>
        [TestMethod]
        public void ReadWritePropertiesIndividualClass()
        {
            var sampleIndividual = new Individual();
            sampleIndividual.Birthdate = new DateTime(1996, 6, 24);
            sampleIndividual.PhoneNumber = "3039609746";
            Assert.AreEqual(sampleIndividual.Birthdate, new DateTime(1996, 6, 24));
            Assert.AreEqual(sampleIndividual.PhoneNumber, "3039609746");
        }
    }
}
