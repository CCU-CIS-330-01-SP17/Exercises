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
    public class NewtonsoftJsonSerializerTests
    {
        [TestMethod]
        public void Verify_NewtonsoftJson_Serializaton_Integrity()
        {
            var clothingArticles = new ClothingArticleList<Shirt>() { new Shirt(DateTime.Now) {Size = 23}, new Shirt(DateTime.Now.AddSeconds(4)) {Size = 24, SleeveLength = 8} };
            var serializer = new NewtonsoftJsonSerializer();

            //Serialize and then deserialize the object.
            serializer.Serialize(clothingArticles, "newtonsoft.dat");
            var deserializedClothingArticles = serializer.Deserialize<Shirt>("newtonsoft.dat");

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
