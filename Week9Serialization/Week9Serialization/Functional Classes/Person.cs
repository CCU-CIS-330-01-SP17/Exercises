using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{

    /// <summary>
    /// This is the base class for both the "Male" and "Female" classes.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Person
    {
        /// <summary>
        /// This method allows the name property to be set on construction
        /// </summary>
        /// <param name="name"></param>
        public Person(string name = null)
        {
            Name = name;
        }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }
    }
}
