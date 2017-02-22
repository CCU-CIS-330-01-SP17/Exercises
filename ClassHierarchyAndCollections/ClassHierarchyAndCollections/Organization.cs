using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A Formal Organization of People.
    /// </summary>
    public class Organization : Contact
    {
        /// <summary>
        /// The list of Individuals who are part of the Organization.
        /// </summary>
        public List<Individual> Members { get; set; }

        /// <summary>
        /// The time when the Organization was founded.
        /// </summary>
        public DateTime FoundingDate { get; private set; }

        /// <summary>
        /// Creates an Organization Object.
        /// </summary>
        /// <param name="name">The Name of the Organization</param>
        /// <param name="primaryPhoneNumber">the Primary Phone Number of the Orginization for contact purposes.</param>
        /// <param name="foundingDate">The time the Organization was founded.</param>
        public Organization(string name, string primaryPhoneNumber, DateTime foundingDate) : base(name, primaryPhoneNumber)
        {
            FoundingDate = foundingDate;
            Members = new List<Individual>();
        }
    }
}
