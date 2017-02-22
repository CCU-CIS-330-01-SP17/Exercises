using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// An Orginization based around an idea or specific purpose.
    /// </summary>
    public class Association : Organization
    {

        /// <summary>
        /// The amount of funds owed by each member on a monthly basis.
        /// </summary>
        public decimal MonthlyDues { get; private set; }

        /// <summary>
        /// The Date and Time of the next association meeting.
        /// </summary>
        public DateTime NextMeeting { get; set; }

        /// <summary>
        /// Creates an Association Object.
        /// </summary>
        /// <param name="name">The Name of the Association.</param>
        /// <param name="primaryPhoneNumber">The Primary Phone Number of the Association.</param>
        /// <param name="foundingDate">The date the Association was founded.</param>
        /// <param name="montlyDues">The amount of funds owed by each member on a monthy basis.</param>
        /// <param name="nextMeeting">The Date and Time of the next association meeting.</param>
        public Association(string name, string primaryPhoneNumber, DateTime foundingDate, decimal montlyDues, DateTime nextMeeting) : base(name, primaryPhoneNumber, foundingDate)
        {
            MonthlyDues = montlyDues;
            NextMeeting = nextMeeting;
        }
    }
}
