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
    public class SchoolTests
    {
        [TestMethod]
        public void Can_Create_School()
        {
            var school = new School("School Name", "555-555-5555", DateTime.Now, "Test ISD", EducationLevel.MiddleSchool);
            Assert.IsInstanceOfType(school, typeof(School));
        }

        [TestMethod]
        public void Can_Read_Write_Properties()
        {
            var school = new School("School Name", "555-555-5555", DateTime.Now, "Test ISD", EducationLevel.MiddleSchool);
            Assert.AreEqual(EducationLevel.MiddleSchool, school.SchoolType);
            Assert.AreEqual("Test ISD", school.DistrictName);
        }

        [TestMethod]
        public void Can_Use_As_Organization()
        {
            var school = new School("School Name", "555-555-5555", DateTime.Now, "Test ISD", EducationLevel.MiddleSchool);
            Assert.IsInstanceOfType(school, typeof(Organization));
        }

        [TestMethod]
        public void Can_Use_As_Contact()
        {
            var school = new School("School Name", "555-555-5555", DateTime.Now, "Test ISD", EducationLevel.MiddleSchool);
            Assert.IsInstanceOfType(school, typeof(Contact));
        }

        [TestMethod]
        public void Can_Be_Graded()
        {
            var school = new School("School Name", "555-555-5555", DateTime.Now, "Test ISD", EducationLevel.MiddleSchool);
            Assert.IsInstanceOfType(school, typeof(IGradable));
        }
    }
}
