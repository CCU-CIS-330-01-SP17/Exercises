using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExercise
{
    /// <summary>
    /// This class represents a dog.
    /// </summary>
    public class Dog
    {
        public int NumberOfLegs { get; set; }

        public string Color { get; set; }

        public void Bark()
        {
            Console.WriteLine("Ruff!");
        }
    }
}
