using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// Defines the ISerializer interface that contains the Serialize() and Deserialize methods;
    /// </summary>
    interface ISerializer
    {
        /// <summary>
        /// Defines a method that serializes a list of Persons. 
        /// </summary>
        void Serialize<T>(PersonList<T> list) where T :Person;

        /// <summary>
        /// Defines a method that deserializes a list of Persons.
        /// </summary>
        PersonList<T> Deserialize<T>(PersonList<T> list) where T:Person;
    }
}
