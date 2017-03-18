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
    public class DataContractSerialize : ISerializer
    {
        void ISerializer.SerializeList(VehicleList<Vehicle> serialList)
        {
            DataContractSerializer serialeze = new DataContractSerializer();

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("_dc-vehicles.xml", settings))
            {
                serialize.WriteObject(writer, serialList);
            }
            Console.WriteLine("Your files has been serialized.");
        }
        VehicleList<Vehicle> ISerializer.DeserializeList(VehicleList<Vehicle> serialList)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(VehicleList<Vehicle>));
            VehicleList<Vehicle> deserializedList = null;

            using (XmlReader reader = XmlReader.Create("_dc-vehicles.txt"))
            {
                deserializedList = serializer.ReadObject(reader) as VehicleList<Vehicle>;
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
