using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// An orginization based around the selling of goods or services in exchange for money.
    /// </summary>
    public class Business : Organization
    {

        /// <summary>
        /// The Chief Executive Officer of the Business.
        /// </summary>
        public Individual ChiefExecutiveOfficer { get; set; }

        /// <summary>
        /// The List of all Employees in the Business.
        /// </summary>
        public List<Individual> Employees { get; set; }

        /// <summary>
        /// Creates a Business Object.
        /// </summary>
        /// <param name="name">The Name of the Business.</param>
        /// <param name="primaryPhoneNumber">The Primary Phone Number of the Business.</param>
        /// <param name="foundingDate">The date the Business was founded.</param>
        /// <param name="chiefExecutiveOfficer">The Chief Executive Officer of the Business. Inserted into list of Employees by default.</param>
        public Business(string name, string primaryPhoneNumber, DateTime foundingDate, Individual chiefExecutiveOfficer) : base(name, primaryPhoneNumber, foundingDate)
        {
            ChiefExecutiveOfficer = chiefExecutiveOfficer;
            Employees = new List<Individual> {chiefExecutiveOfficer};
        }
    }
}
