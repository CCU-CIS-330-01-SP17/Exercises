using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines the Business class
    /// </summary>
    public class Business : Organization, ILocatable
    {
        /// <summary>
        /// This represents the salary of the CEO.
        /// </summary>
        public decimal CEOSalary { get; set; }

        /// <summary>
        /// This represents the number of times the business has been sued.
        /// </summary>
        public int TimesSued { get; set; }

        /// <summary>
        /// The latidude of the contact
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// The longitude of the contact
        /// </summary>
        public string Longitude { get; set; }

        public void PrintCoordinates()
        {
            Console.WriteLine(Latitude + ", " + Longitude);
        }

    }
}
