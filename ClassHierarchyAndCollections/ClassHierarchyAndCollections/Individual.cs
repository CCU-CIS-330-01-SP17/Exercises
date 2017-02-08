using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines Individual and inherets from Contact and ISocialMedia.
    /// </summary>
    public class Individual : Contact, ISocialMedia
    {
        //An individual has a firstname, lastname, address, phone number, email, and an occupation.
        public static int IndividualCount;
        public string individualOccupation { get; set; }
        public string individualEmail { get; set; }

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

        public Individual (string firstName, string lastName, string address, string phoneNumber, 
            string occupation, string email)
            : base (firstName, lastName , address, phoneNumber)
        {
            //Validate the occupation and email for the individual.
            if ((occupation == null) || (occupation.Length < 1))
            {
                throw new ArgumentOutOfRangeException(
                    "occupation", occupation,
                    "Occupation must not be null or blank.");
            }
            if ((email == null) || (email.Length < 1))
            {
                throw new ArgumentOutOfRangeException(
                    "email", email,
                    "Email must not be null or blank.");
            }

            //Saving the occupation and email.
            individualOccupation = occupation;
            individualEmail = email;

            //Incrementing IndividualCount by 1.
            IndividualCount++;
        }
    }
}
