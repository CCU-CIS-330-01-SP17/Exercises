using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableCodingExerciseWeek14
{
    /// <summary>
    /// Defines a vehicle and inherits from IDisposal interface.
    /// </summary>
    public class Vehicle :IDisposable
    {
        public string Name { get; set; }
        /// <summary>
        /// Constructs an instance of a vehicle.
        /// </summary>
        /// <param name="name">A variable used to name the vehicle.</param>
        public Vehicle(string name)
        {
            Name = name;
        }

        void IDisposable.Dispose()
        {
        }
    }
}
