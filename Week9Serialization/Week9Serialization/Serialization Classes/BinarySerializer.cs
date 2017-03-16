using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Week9Serialization
{
    public class BinarySerializer : ISerializer
    {
        public PersonList<T> Deserialize<T>(PersonList<T> list) where T : Person
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream reader = File.OpenRead("_b-persons.txt"))
            {
                return formatter.Deserialize(reader) as PersonList<T>;
            }
        }

        public void Serialize<T>(PersonList<T> list) where T : Person
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.Create("_b-persons.txt"))
            {
                formatter.Serialize(stream, list);
            }
        }
    }
}
