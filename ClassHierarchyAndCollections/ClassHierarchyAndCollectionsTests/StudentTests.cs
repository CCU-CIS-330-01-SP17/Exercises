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
    public class StudentTests
    {
        [TestMethod]
        public void Can_Create_Student()
        {
            var student = new Student("Bob", "911", 7, "Apache Helicopter", 0481344, 3.2f);
            Assert.IsInstanceOfType(student, typeof(Student));
        }

        [TestMethod]
        public void Can_Read_Write_Properties()
        {
            var student = new Student("Bob", "911", 7, "Apache Helicopter", 0481344, 3.2f);
            student.GPA = 3.3f;
            Assert.AreEqual(3.3f, student.GPA);
            Assert.AreEqual(0481344, student.StudentId);
        }

        [TestMethod]
        public void Can_Use_As_Individual()
        {
            var student = new Student("Bob", "911", 7, "Apache Helicopter", 0481344, 3.2f);
            Assert.IsInstanceOfType(student, typeof(Individual));
        }

        [TestMethod]
        public void Can_Use_As_Contact()
        {
            var student = new Student("Bob", "911", 7, "Apache Helicopter", 0481344, 3.2f);
            Assert.IsInstanceOfType(student, typeof(Contact));
        }

        [TestMethod]
        public void Can_Be_Graded()
        {
            var student = new Student("Bob", "911", 7, "Apache Helicopter", 0481344, 3.2f);
            Assert.IsInstanceOfType(student, typeof(IGradable));
        }
    }
}
