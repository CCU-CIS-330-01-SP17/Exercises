using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionCodingExerciseWeek12
{
    public class Car
    {
        public string Model { get; set; }
        public int NumberOfSeats { get; set; }

        public Car(string model, int numberOfSeats)
        {
            Model = model;
            NumberOfSeats = numberOfSeats; 
        }
        public void Drive(int speed, string type)
        {
            Console.WriteLine("I'm going " + speed, type+" !");
       
            //Console.WriteLine("I'm driving.");

            //return true;
        }
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
