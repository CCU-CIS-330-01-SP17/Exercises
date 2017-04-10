using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cryptography;

namespace CryptographyTests
{
    [TestClass]
    public class HasherTests
    {
        [TestMethod]
        public void Hasher_Is_Consistent()
        {
            string hash = Hasher.Hash("123456");
            string sameHash = Hasher.Hash("123456");
            Assert.AreEqual(hash, sameHash);
        }

        [TestMethod]
        public void Hasher_Does_Hash()
        {
            string hash = Hasher.Hash("123456");
            Assert.AreNotEqual("123456", hash);
        }
    }
}
