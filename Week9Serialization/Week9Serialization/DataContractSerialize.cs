using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using System.Collections;

namespace Week9Serialization
{
    /// <summary>
    /// Uses DataContracts to serialize, deserialize, and compare data.
    /// </summary>
    public class DataContractSerialize : ISerializer
    {
        /// <summary>
        /// Uses ISerializer interface to serialize data using DataContracts.
        /// </summary>
        /// <param name="serialList"></param>
        static void SerializeList(VehicleList<Vehicle> serialList)
        {
            DataContractSerializer serialize = new DataContractSerializer(typeof(VehicleList<Vehicle>));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("_dc-vehicles.xml", settings))
            {
                serialize.WriteObject(writer, serialList);
            }
            Console.WriteLine("Your files has been serialized.");
        }
        /// <summary>
        /// Uses ISerializer interface to deserialize data using DataContracts.
        /// </summary>
        /// <param name="serialList"></param>
        /// <returns></returns>
        static VehicleList<Vehicle> DeserializeList()
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(VehicleList<Vehicle>));
            VehicleList<Vehicle> deserializedList = null;

            using (XmlReader reader = XmlReader.Create("_dc-vehicles.txt"))
            {
                deserializedList = serializer.ReadObject(reader) as VehicleList<Vehicle>;
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
