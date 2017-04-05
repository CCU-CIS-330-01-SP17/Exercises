using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionCodingExerciseWeek12
{
    /// <summary>
    /// Class that defines Car that requires two parameters, Model and NumberOfSeats.
    /// </summary>
    public class Car
    {
        public string Model { get; set; }
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// Constructs an instance of Car.
        /// </summary>
        /// <param name="model">Required input to construct an instance of Car. 
        /// Sets Model equal to the passed parameter.</param>
        /// <param name="numberOfSeats">Required input to construct an instance of Car.
        /// Sets NumberOfSeats equal to the passed parameter.</param>
        public Car(string model, int numberOfSeats)
        {
            Model = model;
            NumberOfSeats = numberOfSeats; 
        }
        /// <summary>
        /// Simple method that writes to the console. 
        /// </summary>
        public void Drive()
        {
            Console.WriteLine("I'm driving.");
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
