using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Week9Serialization
{
    /// <summary>
    /// Inherits from the Vehicle class.
    /// Defines a list that is comprised of vehicles. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    [KnownType(typeof(AirPlane))]
    [KnownType(typeof(Car))]
    [KnownType(typeof(Motorcycle))]
    public class VehicleList<T> : List<T> where T : Vehicle
    {
    }
}
