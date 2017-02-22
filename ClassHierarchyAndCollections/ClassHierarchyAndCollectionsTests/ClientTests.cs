using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    /// <summary>
    /// Defines tests for the <see cref="Client"/> class.
    /// </summary>
    [TestClass]
    public class ClientTests
    {
        /// <summary>
        /// This method tests to see if an instance of the "Client" class can be created.
        /// </summary>
        [TestMethod]
        public void CreateInstanceClientClass()
        {
            Client sampleClient = new Client();
            Assert.IsNotNull(sampleClient);
        }

        /// <summary>
        /// This method checks that the "Client" class derives from the "Individual" Class
        /// </summary>
        [TestMethod]
        public void DerivesCorrectlyClientClass()
        {
            Client sampleClient = new Client();
            Assert.IsInstanceOfType(sampleClient, typeof(Individual));
        }

        /// <summary>
        /// This method checks that each property of the "Client" class can be written and read.
        /// </summary>
        [TestMethod]
        public void ReadWritePropertiesClientClass()
        {
            var sampleClient = new Client();
            sampleClient.SubscribedMonthlyNewsletter = false;
            sampleClient.IntroductoryEmailSent = true;
            Assert.AreEqual(sampleClient.SubscribedMonthlyNewsletter, false);
            Assert.AreEqual(sampleClient.IntroductoryEmailSent, true);
        }
    }
}
