using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// An Individual Human Being
    /// </summary>
    public class Individual : Contact
    {
        /// <summary>
        /// The Age of the Individual
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// The Gender of the Individual
        /// </summary>
        public string Gender { get; private set; }

        /// <summary>
        /// Creates an Individual Object.
        /// </summary>
        /// <param name="name">The Name of the Individual</param>
        /// <param name="primaryPhoneNumber">The Primary Phone Number of the Individual</param>
        /// <param name="age">The Age of the Individual</param> 
        /// <param name="gender">The Gender of the Individual</param>
        public Individual(string name, string primaryPhoneNumber, int age, string gender) : base(name, primaryPhoneNumber)
        {
            Age = age;
            Gender = gender;
        }
    }
}
