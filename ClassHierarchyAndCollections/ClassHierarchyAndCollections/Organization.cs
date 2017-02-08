using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines Organization and inherits from Contact.
    /// </summary>
    public class Organization : Contact
    {
        //An organization has a name, formation date, address, phone number, an organization type, 
        //and a contact person.
        public static int OrganizationCount;
        public string organizationFormationDate { get; set; }
        public string organizationType { get; set; }

        public Organization (string firstName, string address, string phoneNumber, string formationDate,
            string type)
            : base (firstName, address, phoneNumber)
        {
            //Validating organizationFormationDate and organizationType.
            if ((formationDate == null) || (formationDate.Length <1))
            {
                throw new ArgumentOutOfRangeException(
                    "formationDate", formationDate,
                    "FormationDate must not be null or blank.");
            }
            if ((type == null) || (type.Length < 1))
            {
                throw new ArgumentOutOfRangeException(
                    "type", type,
                    "Type must not be null or blank.");
            }

            //Saving the formation date and type.
            organizationFormationDate = formationDate;
            organizationType = type;

            //Incrementing OrganizationCount by 1.
            OrganizationCount++;
        }
    }
}
