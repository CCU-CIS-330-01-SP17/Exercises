using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines student and inherets from Inidividual and ISocialMedia.
    /// </summary>
    public class Student : Individual, ISocialMedia
    {
        public static int StudentCount;
        public int studentID { get; set; }
        public string studentSchool { get; set; }

        public new string socialMedia
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Student (string firstName, string lastName, string address, string phoneNumber, string occupation,
            string email, int studentID, string school)
            : base (firstName, lastName, address, phoneNumber, occupation, email)
        {
            //Validate studentID and the studentSchool.
            int i;
            string newStudentID = studentID.ToString();
            bool success = int.TryParse(newStudentID, out i);
            if (success == false)
            {
                throw new ArgumentOutOfRangeException(
                    "studentID", studentID,
                    "StudentID must be an integer.");
            }
            if ((studentSchool == null) || (studentSchool.Length <1))
            {
                throw new ArgumentOutOfRangeException(
                    "school", school,
                    "School must not be null or blank.");
            }
            //Saving studentID and studentSchool
            studentID  = Convert.ToInt32(newStudentID);
            studentSchool = school;

            //Incrementing StudentCount by 1.
            StudentCount++;
        }

    }
}
