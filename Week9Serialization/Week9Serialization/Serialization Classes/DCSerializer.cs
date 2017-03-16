using System.Xml;
using System.Runtime.Serialization;

namespace Week9Serialization
{
    public class DCSerializer : ISerializer
    {
        public PersonList<T> Deserialize<T>(PersonList<T> list) where T : Person
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(PersonList<T>));
            using (XmlReader reader = XmlReader.Create("_dc-persons.xml"))
            {
                return serializer.ReadObject(reader) as PersonList<T>;
            }
        }

        public void Serialize<T>(PersonList<T> list) where T : Person
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(PersonList<T>));
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("_dc-persons.xml", settings))
            {
                serializer.WriteObject(writer, list);
            }
        }
    }
}
