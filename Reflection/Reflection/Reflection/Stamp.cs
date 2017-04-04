using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    /// <summary>
    /// An object used to place ink or other patterns on a medium.
    /// </summary>
    public class Stamp
    {
        /// <summary>
        /// Wether 
        /// </summary>
        public bool IsInked { get; set; }

        /// <summary>
        /// The message the stamp was made to print.
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// Stamps the Message in the console if the stamp is inked.
        /// </summary>
        public string StampMessage()
        {
            return IsInked ? Message : "";
        }

    }
}
