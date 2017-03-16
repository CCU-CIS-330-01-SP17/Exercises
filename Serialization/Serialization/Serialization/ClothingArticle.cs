using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    /// <summary>
    /// This is an object designed to cover the body.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ClothingArticle
    {
        public ClothingArticle(DateTime creationDate)
        {
            CreationDate = creationDate;
        }

        /// <summary>
        /// This is the date the Clothing Article was created.
        /// </summary>
        [DataMember]
        public DateTime CreationDate { get; private set; }

        /// <summary>
        /// This is the size of the clothing. 
        /// </summary>
        [DataMember]
        public int Size { get; set; }
    }
}
