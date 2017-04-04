using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    /// <summary>
    /// A container used for storing liquids.
    /// </summary>
    public class Bottle
    {
        /// <summary>
        /// This bool is True if the bottle is full.
        /// </summary>
        public bool IsFull { get; set; }

        /// <summary>
        /// The Liquid continaed in the bottle.
        /// </summary>
        public string Liquid { get; set; }


        /// <summary>
        /// Fills the bottle with the specified liquid.
        /// </summary>
        public string Fill()
        {
            if (IsFull)
            {
                return "The liquid spills all over the floor...";
            }
            else
            {
                IsFull = true;
                return $"You have filled the bottle with {Liquid}!";
            }
        }

    }
}
