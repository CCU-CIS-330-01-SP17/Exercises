using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// An Individual directly tied to an Organization
    /// </summary>
    public class Member : Individual
    {
        /// <summary>
        /// An honorary moniker and status symbol.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The Date the Member joined the Organization.
        /// </summary>
        public DateTime JoinDate { get; private set; }

        /// <summary>
        /// Creates a Member Object.
        /// </summary>
        /// <param name="name">The name of the Member.</param>
        /// <param name="primaryPhoneNumber">The Primary Phone Number of the Member.</param>
        /// <param name="age">The age of the Member.</param>
        /// <param name="gender">The gender of the Member.</param>
        /// <param name="title">An honorary moniker and status symbol.</param>
        /// <param name="joinDate">The Date the Member joined the Organization.</param>
        public Member(string name, string primaryPhoneNumber, int age, string gender, string title, DateTime joinDate) : base(name, primaryPhoneNumber, age, gender)
        {
            Title = title;
            JoinDate = joinDate;
        }

    }
}
