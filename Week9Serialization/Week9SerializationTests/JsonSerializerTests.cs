using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serialization;
using KellermanSoftware.CompareNetObjects;

namespace Week9SerializationTests
{
    [TestClass]
    public class JsonSerializerTests
    {
        [TestMethod]
        public void JSerializeDeserializeCorrect()
        {
            PersonList<Person> list = new PersonList<Person>();
            list.Add(new Male("George") { Age = 16 });
            list.Add(new Female("Sarah") { Age = 15 });
            // The following code creates a new JSerializer object, then serializes and deserializes the above list.
            JSerializer jsonSerializer = new JSerializer();
            jsonSerializer.Serialize(list);
            PersonList<Person> deserializedList = jsonSerializer.Deserialize(list);
            // The following code compares the original list to the serialized/deserialized list.
            CompareLogic comparer = new CompareLogic();
            var compareResult = comparer.Compare(deserializedList, list);
            // The test will fail if the two lists are not equal.
            Assert.AreEqual(true, compareResult.AreEqual);
        }
    }
}
