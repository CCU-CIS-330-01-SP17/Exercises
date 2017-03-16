using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serialization;
using KellermanSoftware.CompareNetObjects;

namespace Week9SerializationTests
{
    [TestClass]
    public class DataContractSerializerTests
    {
        [TestMethod]
        public void DCSerializeDeserializeCorrect()
        {
            PersonList<Person> list = new PersonList<Person>();
            list.Add(new Male("Jeff") { Age = 26 });
            list.Add(new Female("Martha") { Age = 24 });
            // The following code creates a new DC Serializer object, then serializes and deserializes the above list.
            DCSerializer dataContractSerializer = new DCSerializer();
            dataContractSerializer.Serialize(list);
            PersonList<Person> deserializedList = dataContractSerializer.Deserialize(list);
            // The following code compares the original list to the serialized/deserialized list.
            CompareLogic comparer = new CompareLogic();
            var compareResult = comparer.Compare(deserializedList, list);
            // The test will fail if the two lists are not equal.
            Assert.AreEqual(true, compareResult.AreEqual);
        }
    }
}
