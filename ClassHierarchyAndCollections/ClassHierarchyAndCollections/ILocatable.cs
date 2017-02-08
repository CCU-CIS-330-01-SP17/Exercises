using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Provides the GPS coordinates for the contact
    /// </summary>
    public interface ILocatable
    {
        /// <summary>
        /// The latitude of the contact.
        /// </summary>
        string Latitude { get; set; } 

        /// <summary>
        /// The longitude of the contact.
        /// </summary>
        string Longitude { get; set; }

        void PrintCoordinates();
    }
}
