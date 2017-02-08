using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    /// <summary>
    /// Defines tests for the <see cref="Business"/> class.
    /// </summary>
    [TestClass]
    public class BusinessTests
    {
        /// <summary>
        /// This method tests to see if an instance of the "Business" class can be created.
        /// </summary>
        [TestMethod]
        public void CreateInstanceBusinessClass()
        {
            Business sampleBusiness = new Business();
            Assert.IsNotNull(sampleBusiness);
        }

        /// <summary>
        /// This method checks that the "Business" class derives from the "Organization" Class
        /// </summary>
        [TestMethod]
        public void DerivesCorrectlyBusinessClass()
        {
            Business sampleBusiness = new Business();
            Assert.IsInstanceOfType(sampleBusiness, typeof(Organization));
        }

        /// <summary>
        /// This method checks that each property of the "Business" class can be written and read.
        /// </summary>
        [TestMethod]
        public void ReadWritePropertiesBusinessClass()
        {
            var sampleBusiness = new Business();
            sampleBusiness.CEOSalary= 325000.00m;
            sampleBusiness.TimesSued = 5;
            Assert.AreEqual(sampleBusiness.CEOSalary, 325000.00m);
            Assert.AreEqual(sampleBusiness.TimesSued, 5);
        }

        /// <summary>
        /// This method checks that the Latitude and Longetude properties of the "Business" class (ILocatable Interface) can be written and read.
        /// </summary>
        [TestMethod]
        public void ReadWriteCoordinatesBusinessClass()
        {
            var sampleBusiness = new Business();
            sampleBusiness.Latitude = "30.4173";
            sampleBusiness.Longitude = "-95.1531";
            Assert.AreEqual(sampleBusiness.Latitude, "30.4173");
            Assert.AreEqual(sampleBusiness.Longitude, "-95.1531");
            
        }
    }
}

