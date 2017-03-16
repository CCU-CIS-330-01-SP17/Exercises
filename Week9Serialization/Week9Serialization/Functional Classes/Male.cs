using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// This class inherits from the Person class.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Male : Person
    {
        public Male(string name = null)
            : base(name)
        {
        }
    }
}
