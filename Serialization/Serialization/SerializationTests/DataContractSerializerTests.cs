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
    public class DataContractSerializerTests
    {
        [TestMethod]
        public void Verify_DataContract_Serializaton_Integrity()
        {
            var clothingArticles = new ClothingArticleList<Sock>() { new Sock(DateTime.Now, 13), new Sock(DateTime.Now.AddHours(3), 29) };
            var serializer = new DataContractSerializer();

            //Serialize and then deserialize the object.
            serializer.Serialize(clothingArticles, "dataContract.dat");
            var deserializedClothingArticles = serializer.Deserialize<Sock>("dataContract.dat");

            //Compare the original object to the deserialized object.
            var comparer = new CompareLogic()
            {
                Config = new ComparisonConfig()
                {
                    MaxMillisecondsDateDifference = 5
                }
            };
            var compareResult = comparer.Compare(clothingArticles, deserializedClothingArticles);
            Assert.IsTrue(compareResult.AreEqual);
        }
    }
}
