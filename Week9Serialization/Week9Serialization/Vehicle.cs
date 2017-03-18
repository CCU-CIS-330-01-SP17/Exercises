using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    // Required for Binary serialization.
    [Serializable]
    // Required for DataContract serialization.
    [DataContract]
    public class Vehicle
    {
        public Vehicle (string name = null)
        {
            Name = name;

            Console.WriteLine("This {0} {1} was constructed.", name ?? "<null>", this.GetType().Name);
        }
        [DataMember]
        public string TypeOfMotor { get; set; }
        [DataMember]
        public int NumberOfWheels { get; set; }
        [DataMember]
        public string FuelType { get; set; }
    }
}
