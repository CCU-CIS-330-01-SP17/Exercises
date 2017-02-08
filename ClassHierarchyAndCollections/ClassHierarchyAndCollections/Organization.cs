using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines the Organization class.
    /// </summary>
    public class Organization: Contact
    {
        /// <summary>
        /// This is the name of a specific department within an orginization.
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// This is the date the organization was formed.
        /// </summary>
        public DateTime FormationDate { get; set; }
    }
}
