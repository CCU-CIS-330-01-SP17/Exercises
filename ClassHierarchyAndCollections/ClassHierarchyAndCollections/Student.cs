using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines the Student class
    /// </summary>
    public class Student: Individual
    {
        /// <summary>
        /// This represents the grade point average of the student.
        /// </summary>
        public double GPA { get; set; }

        /// <summary>
        /// This represents the graduation date of the student.
        /// </summary>
        public DateTime GraduationDate { get; set; }
    }
}