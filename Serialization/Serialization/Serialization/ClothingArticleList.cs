using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    [KnownType(typeof(Shirt))]
    [KnownType(typeof(Sock))]
    public class ClothingArticleList<T> : List<T> where T : ClothingArticle
    {
    }
}
