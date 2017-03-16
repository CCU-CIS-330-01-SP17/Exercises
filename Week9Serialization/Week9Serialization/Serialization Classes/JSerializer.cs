using Newtonsoft.Json;
using System.IO;

namespace Week9Serialization
{
    public class JSerializer : ISerializer
    {
        public PersonList<T> Deserialize<T>(PersonList<T> list) where T : Person
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
            using (StreamReader reader = File.OpenText("_nsj-persons.nsj"))
            {
                return serializer.Deserialize(reader, typeof(PersonList<T>)) as PersonList<T>;
            }
        }

        public void Serialize<T>(PersonList<T> list) where T : Person
        {
            JsonSerializer serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamWriter writer = File.CreateText("_nsj-persons.nsj"))
            {
                serializer.Serialize(writer, list);
            }
        }
    }
}
