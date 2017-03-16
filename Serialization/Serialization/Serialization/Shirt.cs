using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    /// <summary>
    /// This is a covering of the upper torso, ocassionally covering the arms as well.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Shirt : ClothingArticle
    {
        public Shirt(DateTime creationDate) : base(creationDate)
        {
        }

        /// <summary>
        /// This is the length of the sleeves of the shirt, in inches.
        /// </summary>
        [DataMember]
        public float SleeveLength { get; set; }
    }
}
