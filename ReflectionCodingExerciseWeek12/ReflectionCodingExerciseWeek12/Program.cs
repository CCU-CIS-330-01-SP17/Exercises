using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionCodingExerciseWeek12
{
    class Program
    {
        static void Main(string[] args)
        {
            Car toyota = new Car("Camry", 5);

            var typeCar = toyota.GetType();

            toyota.GetPropertyInformation(typeCar);

            MethodInfo driveMethod = toyota.GetType().GetMethod("Drive", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int), typeof(string) }, null);
            driveMethod.Invoke(toyota, new object[] { 35, "MPH" });

            Console.ReadKey();
        }
           
    }
}