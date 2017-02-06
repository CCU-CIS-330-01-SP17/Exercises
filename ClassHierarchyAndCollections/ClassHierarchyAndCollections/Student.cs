using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// An Invidual focused on education.
    /// </summary>
    public class Student : Individual, IGradable
    {
        /// <summary>
        /// The ID of the student, as assigned by the District.
        /// </summary>
        public int StudentId { get; private set; }

        /// <summary>
        /// The current GPA of the student.
        /// </summary>
        public float GPA { get; set; }

        /// <summary>
        /// Creates a Student object.
        /// </summary>
        /// <param name="name">The Name of the Student</param>
        /// <param name="primaryPhoneNumber">The Primary Phone Number of the Student.</param>
        /// <param name="age">The age of the Student.</param>
        /// <param name="gender">The gender of the Student.</param>
        /// <param name="studentId">The ID of the student, as assigned by the District.</param>
        /// <param name="gpa">The curent GPA of the student.</param>
        public Student(string name, string primaryPhoneNumber, int age, string gender, int studentId, float gpa) : base(name, primaryPhoneNumber, age, gender)
        {
            StudentId = studentId;
            GPA = gpa;
        }

        public float Grade()
        {
            return GPA;
        }
    }
}
