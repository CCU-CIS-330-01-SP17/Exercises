using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Frog f = new Frog();
            Speak(f);
        }
        class Animal { }
        class Frog : Animal { }

        static void Speak(object obj) { Console.WriteLine("In Speak(object)"); }
        static void Speak(Animal a) { Console.WriteLine("In Speak(Animal)"); }
        static void Speak(Frog f) { Console.WriteLine("In Speak(Frog)"); }
    }
    }


