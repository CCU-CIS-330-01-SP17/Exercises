using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines Contact.
    /// </summary>
    public class Contact
    {
        //A contact has an address, phone number, and a name.
        public static int ContactCount { get; set; }
        public string contactFirstName { get; set; }
        public string contactLastName { get; set; }
        public string contactAddress { get; set; }
        public string contactPhoneNumber { get; set; }

        public Contact(string firstName, string address, string phoneNumber)
        {
            //Validate the first name, address, and phone number.
            if ((firstName == null) || (firstName.Length < 1))
            {
                throw new ArgumentOutOfRangeException(
                    "firstName", firstName,
                    "First name must not be null or blank.");
            }
            if ((address == null) || (address.Length < 1))
            {
                throw new ArgumentOutOfRangeException(
                    "address", address,
                    "Address must not be null or blank.");
            }
            if ((phoneNumber == null) || (phoneNumber.Length < 1))
            {
                throw new ArgumentOutOfRangeException(
                    "phoneNumber", phoneNumber,
                    "Phone number must not be null or blank.");
            }

            //Saving the first name, address, and phone number.
            contactFirstName = firstName;
            contactAddress = address;
            contactPhoneNumber = phoneNumber;

            //Incrementing the contact count by 1.
            ContactCount++;
        }
        public Contact(string firstName, string lastName, string address, string phoneNumber)
        {
            //Validate the first name, address, and phone number.
            if ((firstName == null) || (firstName.Length < 1))
            {
                throw new ArgumentOutOfRangeException(
                    "firstName", firstName,
                    "First name must not be null or blank.");
            }
            if ((lastName == null) || (lastName.Length <1))
            {
                throw new ArgumentOutOfRangeException(
                    "lastName", lastName,
                    "LastName must not be null or blank.");
            }
            if ((address == null) || (address.Length < 1))
            {
                throw new ArgumentOutOfRangeException(
                    "address", address,
                    "Address must not be null or blank.");
            }
            if ((phoneNumber == null) || (phoneNumber.Length < 1))
            {
                throw new ArgumentOutOfRangeException(
                    "phoneNumber", phoneNumber,
                    "Phone number must not be null or blank.");
            }

            //Saving the firstName, lastnName, address, and phone number.
            contactFirstName = firstName;
            contactLastName = lastName;
            contactAddress = address;
            contactPhoneNumber = phoneNumber;

            //Incrementing the contact count by 1.
            ContactCount++;
        }
    }
}
