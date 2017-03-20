using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml;

namespace Week9Serialization
{
    /// <summary>
    /// Uses JsonSerializer to serialize, deserialize, and compare data.
    /// </summary>
    class JsonSerialize : ISerializer
    {
        /// <summary>
        /// Uses ISerializer interface to serialize data using JsonSerializer.
        /// </summary>
        /// <param name="serialList"></param>
        static void SerializeList(VehicleList<Vehicle> serialList)
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamWriter writer = File.CreateText("_nsj-vehicle.json"))
            {
                serializer.Serialize(writer, serialList);
            }
            Console.WriteLine("Your list has been serialized.");
        }
        /// <summary>
        /// Uses ISerializer interface to deserialize data using JsonSerializer.
        /// </summary>
        /// <param name="serialList"></param>
        /// <returns></returns>
        static VehicleList<Vehicle> DeserializeList()
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
            VehicleList<Vehicle> deserializedList = null;
            using (StreamReader reader = File.OpenText("_nsj-vehicle.json"))
            {
                deserializedList = serializer.Deserialize(reader, typeof(VehicleList<Vehicle>)) as VehicleList<Vehicle>;
            }
            Console.WriteLine("Your file has been deserialized.");

            return deserializedList;
        }
        /// <summary>
        /// Compares the data that is passed to the serializer method to the output of the deserializer method to see if they are the same. 
        /// </summary>
        /// <param name="firstObject"></param>
        /// <param name="secondObject"></param>
        /// <param name="config"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        static bool CompareObjects(object firstObject, object secondObject, ComparisonConfig config = null, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            CompareLogic comparer = new CompareLogic();
            if (config != null)
            {
                comparer.Config = config;

                return false;
            }

            var compareResult = comparer.Compare(firstObject, secondObject);

            if (compareResult.AreEqual)
            {
                Console.WriteLine();
                Console.WriteLine("{0}: Objects match", memberName);

                return true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("{0}: Objects DO NOT match!", memberName);
                Console.WriteLine(compareResult.DifferencesString);

                return false;
            }
        }
    }
}
