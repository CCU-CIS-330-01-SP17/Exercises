using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    public class AirPlane : Vehicle
    {
        // Required for Binary serialization.
        [Serializable]
        // Required for DataContract serialization.
        [DataContract]
        public AirPlane(string name = null)
            : base(name);
        {}

    }
}
