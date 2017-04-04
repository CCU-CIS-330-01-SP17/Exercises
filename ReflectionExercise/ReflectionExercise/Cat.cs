using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExercise
{
    /// <summary>
    /// This class represents a cat.
    /// </summary>
    public class Cat
    {
        public int NumberOfLegs { get; set; }

        public string HairColor { get; set; }

        public void Meow()
        {
            Console.WriteLine("Meow!");
        }
    }
}
