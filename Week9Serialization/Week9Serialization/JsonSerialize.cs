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
    class JsonSerialize : ISerializer
    {
        void ISerializer.SerializeList(VehicleList<Vehicle> serialList)
        {
            JsonSerializer serializer = new JsonSerializer();
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamWriter writer = File.CreateText("_nsj-vehicle.json"))
            {
                serializer.Serialize(writer, List);
            }
            Console.WriteLine("Your list has been serialized.");
        }
        VehicleList<Vehicle> ISerializer.DeserializeList(VehicleList<Vehicle> serialList)
        {
            JsonSerializer serializer = new JsonSerializer();
            {
                TypeNameHandlilng = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
            VehicleList<Vehicle> deserializedList = null;
            using (StreamReader reader = File.OpenText("_nsj-vehicle.json"))
            {
                deserializedList = serializer.Deserialize(reader, typeof(VehicleList<Vehicle>)) as VehicleList<Vehicle>;
            }
            Console.WriteLine("Your file has been deserialized.");
        }
        static void CompareObjects(object firstObject, object secondObject, ComparisonConfig config = null, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            CompareLogic comparer = new CompareLogic();
            if (config != null)
            {
                comparer.Config = config;
            }

            var compareResult = comparer.Compare(firstObject, secondObject);

            if (compareResult.AreEqual)
            {
                Console.WriteLine();
                Console.WriteLine("{0}: Objects match", memberName);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("{0}: Objects DO NOT match!", memberName);
                Console.WriteLine(compareResult.DifferencesString);
            }
        }
    }
}
