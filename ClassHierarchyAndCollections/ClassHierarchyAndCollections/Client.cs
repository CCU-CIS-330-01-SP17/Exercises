using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines the Client class.
    /// </summary>
    public class Client : Individual
    {
        /// <summary>
        /// This represents if the client has been sent the introductory email or not.
        /// </summary>
        public bool IntroductoryEmailSent { get; set; }

        /// <summary>
        /// This represents if the client is subscribed to the monthly newsletter or not.
        /// </summary>
        public bool SubscribedMonthlyNewsletter { get; set; }
    }
}

