using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    /// <summary>
    /// Defines tests for the <see cref="Member"/> class.
    /// </summary>
    [TestClass]
    public class MemberTests
    {
        /// <summary>
        /// This method tests to see if an instance of the "Member" class can be created.
        /// </summary>
        [TestMethod]
        public void CreateInstanceMemberClass()
        {
            Member sampleMember = new Member();
            Assert.IsNotNull(sampleMember);
        }

        /// <summary>
        /// This method checks that the "Member" class derives from the "Individual" Class
        /// </summary>
        [TestMethod]
        public void DerivesCorrectlyMemberClass()
        {
            Student sampleMember = new Student();
            Assert.IsInstanceOfType(sampleMember, typeof(Individual));
        }

        /// <summary>
        /// This method checks that each property of the "Member" class can be written and read.
        /// </summary>
        [TestMethod]
        public void ReadWritePropertiesMemberClass()
        {
            var sampleMember = new Member();
            sampleMember.MembershipYears = 6;
            sampleMember.Rank = "Captain";
            Assert.AreEqual(sampleMember.Rank, "Captain");
            Assert.AreEqual(sampleMember.MembershipYears, 6);
        }
    }
}
