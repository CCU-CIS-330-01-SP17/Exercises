using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines Client and inherits from Individual and ISocialMedia
    /// </summary>
    public class Client : Individual, ISocialMedia
    {
        public static int ClientCount;
        public string clientOrganization { get; set; }
        public string clientPolicyNumber { get; set; }

        public Client(string firstName, string lastName, string address, string phoneNumber, string occupation,
            string email, string organization, string policyNumber)
            : base (firstName, lastName, address, phoneNumber, occupation, email)
        {
            //Validate clientOrganization and clientPolicyNumber.
            if ((organization == null) || (organization.Length <1))
            {
                throw new ArgumentOutOfRangeException(
                    "clientOrgnaization", organization,
                    "ClientOrganization must not be null or blank.");
            }
            if ((clientPolicyNumber == null) || (clientPolicyNumber.Length <1))
            {
                throw new ArgumentOutOfRangeException(
                    "clientPolicyNumber", policyNumber,
                    "ClientPolicyNumber must not be null or blank.");
            }
            //Saving clientOrganziation and clientPolicyNumber
            clientOrganization = organization;
            clientPolicyNumber = policyNumber;

            //Incrementing ClientCount by 1.
            ClientCount++;
        }
    }
}
