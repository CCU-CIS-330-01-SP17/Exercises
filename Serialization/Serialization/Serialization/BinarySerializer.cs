using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    /// <summary>
    /// This uses BinaryFormatter to serialize objects to binary.
    /// </summary>
    public class BinarySerializer : ISerializer
    {
        /// <summary>
        /// This converts objects to binary.
        /// </summary>
        /// <param name="clothingArticleList">This is the ClothingArticleList instance to serialize.</param>
        /// <param name="filePath">This is where the Serialized Result should be saved.</param>
        public void Serialize<T>(ClothingArticleList<T> clothingArticleList, string filePath) where T : ClothingArticle
        {
            var formatter = new BinaryFormatter();

            using (var stream = File.Create(filePath))
            {
                formatter.Serialize(stream, clothingArticleList);
            }
        }

        /// <summary>
        /// This converts binary files into the objects they were created from.
        /// </summary>
        /// <param name="filePath">This is where the Serialized File should be read from.</param>
        /// <returns>This returns a ClothingArticleList containing the specified type of clothing.</returns>
        public ClothingArticleList<T> Deserialize<T>(string filePath) where T : ClothingArticle
        {
            var formatter = new BinaryFormatter();

            using (var reader = File.OpenRead(filePath))
            {
                return formatter.Deserialize(reader) as ClothingArticleList<T>;
            }
        }
    }
}
