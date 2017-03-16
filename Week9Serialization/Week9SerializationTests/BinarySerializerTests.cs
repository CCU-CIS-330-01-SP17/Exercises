using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serialization;

namespace Week9SerializationTests
{
    /// <summary>
    /// This class contains all tests for the <see cref="BinarySerializer"/> class.
    /// </summary>
    [TestClass]
    public class BinarySerializerTests
    {
        [TestMethod]
        public void BinarySerializeDeserializeCorrect()
        {
            PersonList<Person> list = new PersonList<Person>();
            list.Add(new Male("John") {Age = 56 });
            list.Add(new Female("Donna") { Age = 54 });
            // The following code creates a new Binary Serializer object, then serializes and deserializes the above list.
            BinarySerializer bSerializer = new BinarySerializer();
            bSerializer.Serialize(list);
            PersonList<Person> deserializedList = bSerializer.Deserialize(list);
            // The following code compares the original list to the serialized/deserialized list.
            CompareLogic comparer = new CompareLogic();
            var compareResult = comparer.Compare(deserializedList, list);
            // The test will fail if the two lists are not equal.
            Assert.AreEqual(true, compareResult.AreEqual);
        }
    }
}
