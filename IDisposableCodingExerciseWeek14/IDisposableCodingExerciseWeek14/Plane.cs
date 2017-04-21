using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableCodingExerciseWeek14
{
    /// <summary>
    /// Defines a plane and inherits from the Vehicle class.
    /// </summary>
    public class Plane : Vehicle
    {
        public string airplnneType { get; set; }

        /// <summary>
        /// Contructs a plane.
        /// </summary>
        /// <param name="type">A basic variable to name the plane.</param>
        public Plane(string type)
        : base (type)
        {
            airplnneType = type;
        }

    }
}
