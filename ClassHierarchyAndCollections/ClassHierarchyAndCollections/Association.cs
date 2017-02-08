using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines the Association class
    /// </summary>
    public class Association: Organization
    {
        /// <summary>
        /// This represents the yearly cost fees to be a member of the Association.
        /// </summary>
        public decimal AnnualDues { get; set; }

        /// <summary>
        /// This represents the abbreviation of the Association.
        /// </summary>
        public string Acronym { get; set; }
    }
}
