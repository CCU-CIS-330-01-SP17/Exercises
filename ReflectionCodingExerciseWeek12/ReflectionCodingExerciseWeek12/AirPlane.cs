using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionCodingExerciseWeek12
{
    /// <summary>
    /// Class that defines AirPlane and that requires to parameters, AirPlaneType and NumberOfPassengers.
    /// </summary>
    public class AirPlane
    {
        public string AirPlaneType { get; set; }
        public int NumberOfPassengers { get; set; }
       /// <summary>
       /// Constructs an instance of AirPlane.
       /// </summary>
       /// <param name="airPlane">Required to construct an instance of AirPlane.
       /// Sets the passed parameter equal to AirPlaneType.</param>
       /// <param name="passengers">Required to construct an instance of AirPlane.
       /// Sets the passed parameter equal to NumberOfPassengers.</param>
        public AirPlane(string airPlane, int passengers)
        {
            AirPlaneType = airPlane;
            NumberOfPassengers = passengers;
        }
        /// <summary>
        /// Simple method that writes to the console. 
        /// </summary>
        public void Fly()
        {
            Console.WriteLine("I'm flying.");
        }
        /// <summary>
        /// Gets the property types of Car.
        /// </summary>
        /// <param name="type">The type that needs the property extracted from.</param>
        /// <returns>Returns int to the caller for test purposes.</returns>
        public int GetPropertyInformation(Type type)
        {
            int testValidation = 0;

            foreach (var property in type.GetProperties())
            {
                Console.WriteLine($"Property: {property.Name}: {property.PropertyType.Name}");
                Console.WriteLine($"          CanRead: {property.CanRead}");
                Console.WriteLine($"          CanWrite: {property.CanWrite}");

                if (property.CanRead == true && property.CanWrite == true)
                {
                    testValidation++;
                }
                else
                {
                    testValidation--;
                }
            }
            return testValidation;
        }
    }
}
