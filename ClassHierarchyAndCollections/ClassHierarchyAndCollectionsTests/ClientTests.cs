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
    public class ClientTests
    {
        [TestMethod]
        public void Can_Create_Client()
        {
            var client = new Client("Bob", "911", 7, "Apache Helicopter", DateTime.Now, 5);
            Assert.IsInstanceOfType(client, typeof(Client));
        }

        [TestMethod]
        public void Can_Read_Write_Properties()
        {
            var lastTransactionDate = DateTime.Now;
            var client = new Client("Bob", "911", 7, "Apache Helicopter", lastTransactionDate, 5);
            Assert.AreEqual(lastTransactionDate, client.LastTransactionDate);
            Assert.AreEqual(5, client.TransactionCount);
        }

        [TestMethod]
        public void Can_Use_As_Individual()
        {
            var client = new Client("Bob", "911", 7, "Apache Helicopter", DateTime.Now, 5);
            Assert.IsInstanceOfType(client, typeof(Individual));
        }

        [TestMethod]
        public void Can_Use_As_Contact()
        {
            var client = new Client("Bob", "911", 7, "Apache Helicopter", DateTime.Now, 5);
            Assert.IsInstanceOfType(client, typeof(Contact));
        }
    }
}
