using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionCodingExerciseWeek12
{
    class AirPlane
    {
        public AirPlane()
        {
        }

        public string AirPlaneType { get; set; }
        public int  NumberOfPassengers { get; set; }

        public void Fly()
        {
            Console.WriteLine("I'm flying.");
        }
    }
}
