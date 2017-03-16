using System.IO;
using System.Runtime.Serialization.Json;

namespace Serialization
{
    /// <summary>
    /// This serializes and deserializes objects into and from JSON
    /// </summary>
    public class DataContractSerializer : ISerializer
    { 
        /// <summary>
        /// This serializes a ClothingArticleList into JSON and saves it to disk.
        /// </summary>
        /// <typeparam name="T">This is the type of ClothingArticle contained within the list.</typeparam>
        /// <param name="clothingArticleList">This is the ClothingArticleList to serialize.</param>
        /// <param name="filePath">This is the path to where the JSON should be saved on disk.</param>
        public void Serialize<T>(ClothingArticleList<T> clothingArticleList, string filePath) where T : ClothingArticle
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ClothingArticleList<T>));

            using (var fileStream = File.Create(filePath))
            {
                serializer.WriteObject(fileStream, clothingArticleList);
            }
        }

        /// <summary>
        /// This method deserialies a json-serialized ClothingArticleList and converts it back into an object.
        /// </summary>
        /// <typeparam name="T">This is the type of clothing article the ClothingArticleList contains.</typeparam>
        /// <param name="filePath">This is the path to where the serialized file is located.</param>
        /// <returns></returns>
        public ClothingArticleList<T> Deserialize<T>(string filePath) where T : ClothingArticle
        {
            var serializer = new DataContractJsonSerializer(typeof(ClothingArticleList<T>));

            using (var reader = new StreamReader(filePath))
            {
                return serializer.ReadObject(reader.BaseStream) as ClothingArticleList<T>;
            }
        }
    }
}
