using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    /// <summary>
    /// Defines tests for the <see cref="School"/> class.
    /// </summary>
    [TestClass]
    public class SchoolTests
    {
        /// <summary>
        /// This method tests to see if an instance of the "School" class can be created.
        /// </summary>
        [TestMethod]
        public void CreateInstanceSchoolClass()
        {
            School sampleSchool = new School();
            Assert.IsNotNull(sampleSchool);
        }

        /// <summary>
        /// This method checks that the "School" class derives from the "Organization" Class
        /// </summary>
        [TestMethod]
        public void DerivesCorrectlySchoolClass()
        {
            School sampleSchool = new School();
            Assert.IsInstanceOfType(sampleSchool, typeof(Organization));
        }

        /// <summary>
        /// This method checks that each property of the "School" class (except the read-only "Students" property) can be written and read.
        /// </summary>
        [TestMethod]
        public void ReadWritePropertiesSchoolClass()
        {
            var sampleSchool = new School();
            sampleSchool.HasCISProgram = true;
            sampleSchool.Tuition = 15000.00m;
            Assert.AreEqual(sampleSchool.HasCISProgram, true);
            Assert.AreEqual(sampleSchool.Tuition, 15000.00m);
        }
    }
}


