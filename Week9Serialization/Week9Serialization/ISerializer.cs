using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// Creates an interface for the different serializers to use.
    /// </summary>
    interface ISerializer
    {
        void SerializeList(VehicleList<Vehicle> serialList);

        VehicleList<Vehicle> DeserializeList();
    }
}
