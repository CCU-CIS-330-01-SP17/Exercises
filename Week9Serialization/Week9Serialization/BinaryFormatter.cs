using KellermanSoftware.CompareNetObjects;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Week9Serialization
{
    /// <summary>
    /// Uses BinaryFormatter to serialize, deserialize, and compare data.
    /// </summary>
    public class BinaryFormat : ISerializer
    {
        /// <summary>
        /// Uses ISerializer interface to serialize data using BinaryFormatter.
        /// </summary>
        /// <param name="list"></param>
        static void SerializeList(VehicleList<Vehicle> list)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = File.Create("_b-vehicle.txt"))
            {
                formatter.Serialize(stream, list);
            }
            Console.WriteLine("Your list has been serialized.");
        }
        /// <summary>
        /// Uses ISerializer interface to deserialize data using BinaryFormatter.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        static VehicleList<Vehicle> DeserializeList() 
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
