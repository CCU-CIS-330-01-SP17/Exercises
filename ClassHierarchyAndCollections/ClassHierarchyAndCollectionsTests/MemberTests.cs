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
    public class MemberTests
    {
        [TestMethod]
        public void Can_Create_Member()
        {
            var member = new Member("Bob", "911", 7, "Apache Helicopter", "Youngster", DateTime.Now);
            Assert.IsInstanceOfType(member, typeof(Member));
        }

        [TestMethod]
        public void Can_Read_Write_Properties()
        {
            var timeJoined = DateTime.Now;
            var member = new Member("Bob", "911", 7, "Apache Helicopter", "Youngster", timeJoined);
            member.Title = "Youngun";
            Assert.AreEqual(timeJoined, member.JoinDate);
            Assert.AreEqual("Youngun", member.Title);
        }

        [TestMethod]
        public void Can_Use_As_Individual()
        {
            var member = new Member("Bob", "911", 7, "Apache Helicopter", "Youngster", DateTime.Now);
            Assert.IsInstanceOfType(member, typeof(Individual));
        }

        [TestMethod]
        public void Can_Use_As_Contact()
        {
            var member = new Member("Bob", "911", 7, "Apache Helicopter", "Youngster", DateTime.Now);
            Assert.IsInstanceOfType(member, typeof(Contact));
        }
    }
}
