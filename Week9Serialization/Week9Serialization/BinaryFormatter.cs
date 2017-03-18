using KellermanSoftware.CompareNetObjects;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Week9Serialization
{
    public class BinaryFormat : ISerializer
    {
        void ISerializer.SerializeList(VehicleList<Vehicle> list)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = File.Create("_b-vehicle.txt"))
            {
                formatter.Serialize(stream, list);
            }
            Console.WriteLine("Your list has been serialized.");
        }
        VehicleList<Vehicle> ISerializer.DeserializeList(VehicleList<Vehicle> list) 
        {
            BinaryFormatter formatter = new BinaryFormatter();

            VehicleList<Vehicle> deserializedList = null;
            using (FileStream reader = File.OpenRead("_b-vehicle.txt"))
            {
                deserializedList = formatter.Deserialize(reader) as VehicleList<Vehicle>;
            }
            Console.WriteLine("Your file has been deserialized.");
            return deserializedList;
            
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
