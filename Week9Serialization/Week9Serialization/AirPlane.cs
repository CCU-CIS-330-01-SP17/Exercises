using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// A type of vehicle that inherits from the Vehicle class. 
    /// </summary>
    // Required for Binary serialization.
    [Serializable]
    // Required for DataContract serialization.
    [DataContract]
    public class AirPlane : Vehicle
    {
        public AirPlane(string name = null)
            : base(name)
        { }
    }
}
