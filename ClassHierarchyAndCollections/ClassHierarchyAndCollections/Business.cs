using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines Business and inherits from Organization and ISocialMedia.
    /// </summary>
    public class Business : Organization, ISocialMedia
    {
        public static int BusinessCount;
        public string businessOrganizationalStructure { get; set; }
        public string businessBestCoreValue { get; set; }

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

        public Business(string name, string address, string phoneNumber, string formationDate, string type,
            string organizationalStructure, string bestCoreValue)
            : base(name, address, phoneNumber, formationDate, type)
        {
            //Validating businessOrganizationalStructure and businessBestCoreValue.
            if ((organizationalStructure == null) || (organizationalStructure.Length <1))
            {
                throw new ArgumentOutOfRangeException(
                    "businessOrganizationalStructure", organizationalStructure,
                    "OrganizationalStrucutre must not be null or blank.");
            }
            if ((bestCoreValue == null) || (bestCoreValue.Length <1))
            {
                throw new ArgumentOutOfRangeException(
                    "businessBestCoreValue", bestCoreValue,
                    "BestCoreValue must not be null or blank.");
            }

            //Saving businessOrganizationalStructure and businessBestCoreValue.
            businessOrganizationalStructure = organizationalStructure;
            businessBestCoreValue = bestCoreValue;

            //Incrementing BusinessCount by 1.
            BusinessCount++;
        }
    }
}
