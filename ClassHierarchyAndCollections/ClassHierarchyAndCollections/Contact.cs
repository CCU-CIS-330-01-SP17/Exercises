using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Information revolving around a known entity and how to communicate with them.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// The Name of the Contact.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The Primary Phone Number of the Contact.
        /// </summary>
        public string PrimaryPhoneNumber { get; private set; }
        /// <summary>
        /// Creates a Contact Object.
        /// </summary>
        /// <param name="name">The Name of the Contact.</param>
        /// <param name="primaryPhoneNumber">The Primary Phone Number of the Contact.</param>
        public Contact(string name, string primaryPhoneNumber)
        {
            this.Name = name;
            this.PrimaryPhoneNumber = primaryPhoneNumber;
        }
    }
}
