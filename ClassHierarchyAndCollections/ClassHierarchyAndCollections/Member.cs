using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines the Member class.
    /// </summary>
    public class Member : Individual
    {
        /// <summary>
        /// This represents how many years the member has been with the organization.
        /// </summary>
        public int MembershipYears { get; set; }

        /// <summary>
        /// This represents the rank of the member.
        /// </summary>
        public string Rank { get; set; }
    }
}
