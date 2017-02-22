using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A Orginization focused around the education of students.
    /// </summary>
    public class School : Organization, IGradable
    {
        /// <summary>
        /// The name of the district this School is part of.
        /// </summary>
        public string DistrictName { get; private set; }

        /// <summary>
        /// The level of education this school falls under
        /// </summary>
        public EducationLevel SchoolType { get; private set; }

        /// <summary>
        /// Creates a School Object
        /// </summary>
        /// <param name="name">The Name of the School.</param>
        /// <param name="primaryPhoneNumber">The Primary Phone Number of the School.</param>
        /// <param name="foundingDate">The Date the School was founded.</param>
        /// <param name="districtName">The Name of the School District.</param>
        /// <param name="schoolType">The Level of Education the school teaches.</param>
        public School(string name, string primaryPhoneNumber, DateTime foundingDate, string districtName, EducationLevel schoolType) : base(name, primaryPhoneNumber, foundingDate)
        {
            SchoolType = schoolType;
            DistrictName = districtName;
        }

        /// <summary>
        /// Determines the Grade of the School
        /// </summary>
        /// <returns></returns>
        public float Grade()
        {
            bool bribe = true;
            return bribe ? 3.8f : 1.2f;
        }
    }
}
