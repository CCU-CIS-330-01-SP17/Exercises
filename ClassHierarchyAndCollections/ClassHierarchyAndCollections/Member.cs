using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines Member and inherits from Individual and ISocialMedia.
    /// </summary>
    public class Member : Individual, ISocialMedia
    {
        public static int MemberCount;
        public string memberRepresenative { get; set; }
        public string memberSince { get; set; }

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

        public Member (string firstName, string lastName, string address, string phoneNumber, string occupation,
            string email, string represenative, string since)
            : base(firstName, lastName, address, phoneNumber, occupation, email)
        {
            //Validating memberSince and memberRepresenative.
            if ((since == null) || (since.Length <1))
            {
                throw new ArgumentOutOfRangeException(
                    "since", since,
                    "MemberSince must not be null or blank.");
            }
            if ((memberRepresenative == null) || (memberRepresenative.Length <1))
            {
                throw new ArgumentOutOfRangeException(
                    "memberRepresenative", memberRepresenative,
                    "MemberRepresenative must not be null or blank.");
            }
            //Saving memberRepresenative and memberSince.
            memberRepresenative = represenative;
            memberSince = since;

            //Incrementing MemberCount by 1.
            MemberCount++;
        }
    }
}
