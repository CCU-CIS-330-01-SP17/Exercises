using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// An individual that purchases something from a Business.
    /// </summary>
    public class Client : Individual
    {

        /// <summary>
        /// The Time of the last transaction.
        /// </summary>
        public DateTime LastTransactionDate { get; set; }

        /// <summary>
        /// The number of transactions with this client.
        /// </summary>
        public int TransactionCount { get; set; }

        /// <summary>
        /// Creates a Client object.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <param name="primaryPhoneNumber">The primary phone number of the client.</param>
        /// <param name="age">The age of the client.</param>
        /// <param name="gender">The gender of the client.</param>
        /// <param name="lastTransactionDate">The Time of the last transaction</param>
        /// <param name="transactionCount"> The number of transactions with this client.</param>
        public Client(string name, string primaryPhoneNumber, int age, string gender, DateTime lastTransactionDate, int transactionCount) : base(name, primaryPhoneNumber, age, gender)
        {
            LastTransactionDate = lastTransactionDate;
            TransactionCount = transactionCount;
        }
    }
}
