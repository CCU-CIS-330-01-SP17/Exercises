using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines the School class
    /// </summary>
    public class School : Organization
    {
        /// <summary>
        /// This represents the semester cost to attend the school.
        /// </summary>
        public decimal Tuition { get; set; }

        /// <summary>
        /// This states if the school has a CIS program.
        /// </summary>
        public bool HasCISProgram { get; set; }

        /// <summary>
        /// A list of all students in the school.
        /// </summary>
        public List<Student> Students { get; }
    }
}
