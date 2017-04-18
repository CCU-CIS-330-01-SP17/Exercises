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
    /// Represents a person.
    /// </summary>
    public class Person : IDisposable
    {
        /// <summary>
        /// Represents the name of a person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Flag: Has Disponse already been called?
        /// </summary>
        public bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        /// <summary>
        /// This method is a public implementation of Dispose callable by consumers.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }
    }
}
