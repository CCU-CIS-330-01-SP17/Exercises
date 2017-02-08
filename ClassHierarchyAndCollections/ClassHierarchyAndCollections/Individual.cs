using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines the Individual class.
    /// </summary>
    public class Individual : Contact
    {
        /// <summary>
        /// This is the phone number for the individual.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// This is the individuals birthdate.
        /// </summary>
        public DateTime Birthdate { get; set; }
    }
}
