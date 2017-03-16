using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization;

namespace SerializationTests
{
    [TestClass]
    public class BinarySerializerTests
    {
        [TestMethod]
        public void Verify_Binary_Serializaton_Integrity()
        {
            var clothingArticles = new ClothingArticleList<Sock>() { new Sock(DateTime.Now, 16), new Sock(DateTime.MaxValue, 40) };
            var serializer = new BinarySerializer();

            //Serialize and then deserialize the object.
            serializer.Serialize(clothingArticles, "binary.dat");
            var deserializedClothingArticles = serializer.Deserialize<Sock>("binary.dat");

            //Compare the original object to the deserialized object.
            var compareResult = new CompareLogic().Compare(clothingArticles, deserializedClothingArticles);
            Assert.IsTrue(compareResult.AreEqual);
        }
    }
}
