using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    /// <summary>
    /// This is an article of clothing that covers the foot.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Sock : ClothingArticle
    {
        public Sock(DateTime creationDate, float length) : base(creationDate)
        {
            Length = length;
        }

        /// <summary>
        /// This is the length of the sock from toe to top, in inches.
        /// </summary>
        [DataMember]
        public float Length { get; set; }

        /// <summary>
        /// This is the hexadecimal color of the sock.
        /// </summary>
        [DataMember]
        public string Color { get; set; }

    }
}
