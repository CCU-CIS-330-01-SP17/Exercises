using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines School and inherets from Organization and ISocialMedia
    /// </summary>
    public class School : Organization, ISocialMedia
    {
        public static int SchoolCount;
        public string schoolMascot { get; set; }
        public string schoolColors { get; set; }

        public string socialMedia
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

        public School (string name, string address, string phoneNumber, string formationDate, string type,
            string mascot, string colors)
            : base (name, address, phoneNumber, formationDate, type)
        {
            //Validating schoolMascot and schoolColors.
            if ((mascot == null) || (mascot.Length <1))
            {
                throw new ArgumentOutOfRangeException(
                    "schoolMascot", mascot,
                    "SchoolMascot must not be null or blank.");
            }
            if ((colors == null) || (colors.Length <1))
            {
                throw new ArgumentOutOfRangeException(
                    "schoolColors", colors,
                    "SchoolColors must not be null or blank.");
            }

            //Saving schoolMascot and schoolColors.
            schoolMascot = mascot;
            schoolColors = colors;

            //Incrementing SchoolCount by 1.
            SchoolCount++;

            List<Student> Students = new List<Student>();
        }
    }
}
