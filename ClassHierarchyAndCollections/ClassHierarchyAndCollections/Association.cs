using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines Association and inherits from Organization and ISocialMedia.
    /// </summary>
    public class Association : Organization, ISocialMedia
    {
        public static int AssociationCount;
        public string associationInitiationPractice { get; set; }
        public decimal associationAnnualDues { get; set; }

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

        public Association(string firstName, string address, string phoneNumber, string formationDate,
            string type, string initiationPractice, decimal annualDues)
            : base (firstName, address, phoneNumber, formationDate, type)
        {
            //Valating associationInitiationPractice and associationAnnualDues.
            if ((initiationPractice == null) || (initiationPractice.Length < 1))
            {
                throw new ArgumentOutOfRangeException(
                      "associationInitiationPractice", initiationPractice,
                      "InitiationPractice must not be null or blank.");
            }
            decimal value;
            string newAnnualDues = annualDues.ToString();
            bool success = decimal.TryParse(newAnnualDues, out value);
            if (success == false)
            {
                throw new ArgumentOutOfRangeException(
                    "annualDues", annualDues,
                    "AnnualDues must be a decimal.");
            }

            //Saving associationInitiationPractice and associationAnnualDues.
            associationInitiationPractice = initiationPractice;
            associationAnnualDues = annualDues;

            //Incrementing AssociationCount by 1.
            AssociationCount++;
        }
    }
}
