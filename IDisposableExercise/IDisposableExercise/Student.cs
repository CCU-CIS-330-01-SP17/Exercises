using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableExercise
{
    /// <summary>
    /// Represents a student person.
    /// </summary>
    public class Student : Person
    {
        /// <summary>
        /// Represents the student's grade in school.
        /// </summary>
        public string Grade { get; set; }
    }
}