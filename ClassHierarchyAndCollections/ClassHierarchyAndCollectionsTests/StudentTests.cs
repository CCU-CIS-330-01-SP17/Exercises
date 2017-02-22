using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    /// <summary>
    /// Defines tests for the <see cref="Student"/> class.
    /// </summary>
    [TestClass]
    public class StudentTests
    {
        /// <summary>
        /// This method tests to see if an instance of the "Student" class can be created.
        /// </summary>
        [TestMethod]
        public void CreateInstanceStudentClass()
        {
            Student sampleStudent = new Student();
            Assert.IsNotNull(sampleStudent);
        }

        /// <summary>
        /// This method checks that the "Student" class derives from the "Individual" Class
        /// </summary>
        [TestMethod]
        public void DerivesCorrectlyStudentClass()
        {
            Student sampleStudent = new Student();
            Assert.IsInstanceOfType(sampleStudent, typeof(Individual));
        }

        /// <summary>
        /// This method checks that each property of the "Student" class can be written and read.
        /// </summary>
        [TestMethod]
        public void ReadWritePropertiesStudentClass()
        {
            var sampleStudent = new Student();
            sampleStudent.GPA = 3.52;
            sampleStudent.GraduationDate = new DateTime(2018, 5, 25);
            Assert.AreEqual(sampleStudent.GPA, 3.52);
            Assert.AreEqual(sampleStudent.GraduationDate, new DateTime(2018, 5, 25));
        }
    }
}

