using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    /// <summary>
    /// This interface is for serializers which serialize ClothingArticleLists.
    /// </summary>
    public interface ISerializer
    {
        void Serialize<T>(ClothingArticleList<T> listToSerialize, string filePath) where T : ClothingArticle;

        ClothingArticleList<T> Deserialize<T>(string filePath) where T: ClothingArticle;
    }
}
