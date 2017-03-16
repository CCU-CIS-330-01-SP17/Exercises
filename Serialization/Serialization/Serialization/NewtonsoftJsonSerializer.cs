using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Serialization
{
    /// <summary>
    /// This uses NewtonsoftJson to serialize and deserialize ClothingArticleLists.
    /// </summary>
    public class NewtonsoftJsonSerializer : ISerializer
    {
        /// <summary>
        /// This serializes a ClothingArticleList to a json file.
        /// </summary>
        /// <typeparam name="T">This is the type of ClothingArticle the list contains.</typeparam>
        /// <param name="clothingArticleList">This is the ClothingArticleList instance to serialize.</param>
        /// <param name="filePath">This is the location to save the json file.</param>
        public void Serialize<T>(ClothingArticleList<T> clothingArticleList, string filePath) where T : ClothingArticle
        {
            var serializer = new JsonSerializer();

            using (var writer = File.CreateText(filePath))
            {
                serializer.Serialize(writer, clothingArticleList);
            }
        }

        /// <summary>
        /// Deserialize a json-serialized ClothingArticleList back to an object instance.
        /// </summary>
        /// <typeparam name="T">This is the ClothingArticleList instance to serialize.</typeparam>
        /// <param name="filePath">This is the filepath where the serialized ClothingArticleList is saved.</param>
        /// <returns></returns>
        public ClothingArticleList<T> Deserialize<T>(string filePath) where T : ClothingArticle
        {
            var serializer = new JsonSerializer();

            using (var reader = File.OpenText(filePath))
            {
                return serializer.Deserialize(reader, typeof(ClothingArticleList<T>)) as ClothingArticleList<T>;
            }
        }
    }
}
