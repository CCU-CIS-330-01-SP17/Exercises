using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    interface ISerializer
    {
        void SerializeList(VehicleList<Vehicle> serialList);

        VehicleList<Vehicle> DeserializeList(VehicleList<Vehicle> serialList);
    }
}
