using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableCodingExerciseWeek14
{
    /// <summary>
    /// Class that attempts to complete assignment.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Method that facilitates a comparison of not using disposal memory and disposal memory.
        /// </summary>
        public void Main()
        {
            WithoutDisposing();
            Console.WriteLine("Done NOT using IDisposal.");
            Console.ReadKey();
            WithAUsingDisposal();
            Console.WriteLine("Done using IDisposal.");
            Console.ReadKey();
        }
        /// <summary>
        /// Shows execution of the plane class and calculates memory used not using disposal.
        /// </summary>
        public void WithoutDisposing()
        {
            int maxIterations = 10;
            int numberOfPlanes = 0;
            int memoryUsed = 0;

            for (int i = 0; i < maxIterations; i++)
            {
                int name = i;
                Plane plane = new Plane("Aircraft" + name);
                
                for(int t =0; t<100; t++)
                {
                    Console.WriteLine("Part "+t+" added to plane.");
                }
                Console.WriteLine(plane.airplnneType + " was created.");
                numberOfPlanes++;
                Console.WriteLine("Memory Used: {0:n0} bytes", GC.GetTotalMemory(true));
                memoryUsed =+ (int)GC.GetTotalMemory(true);
            }
            Console.WriteLine("Non-Disposal->Total Memory: {0:n0} bytes", memoryUsed);
        }
        /// <summary>
        /// Shows execution of the plane class and calculates memory used using disposal.
        /// </summary>
        public void WithAUsingDisposal()
        {
            int maxIterations = 10;
            int numberOfPlanes = 0;
            int memoryUsed = 0;
            for (int i = 0; i < maxIterations; i++)
            {
                int name = i;
                

                using (Plane plane = new Plane("Aircraaft" + name))
                {
                    for (int t = 0; t <100; t++)
                    {
                        Console.WriteLine("Part "+t+" added to plane.");
                    }
                    Console.WriteLine(plane.airplnneType + " was created.");
                }
                numberOfPlanes++;
                Console.WriteLine("Memory Used: {0:n0} bytes", GC.GetTotalMemory(true));
                memoryUsed =+ (int)GC.GetTotalMemory(true);
            }
            Console.WriteLine("Disposal->Total Memory: {0:n0} bytes", memoryUsed);
        }
    }
}