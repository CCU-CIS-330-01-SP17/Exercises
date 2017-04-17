using System;

namespace Disposable
{
    /// <summary>
    /// A handheld object used for writing.
    /// </summary>
    public class WritingUntensil : IDisposable
    {
        private ConsoleColor _inkColor;
        private bool _isDisposed;

        /// <summary>
        /// Creates a WritingUtensil
        /// </summary>
        /// <param name="inkColor">The color of the ink of the WritingUtensil.</param>
        public WritingUntensil(ConsoleColor inkColor)
        {
            _inkColor = inkColor;
            _isDisposed = false;
        }

        /// <summary>
        /// Readies the WritingUtensil for disposal.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Readies the WritingUtensil for disposal and disables functionality.
        /// </summary>
        /// <param name="disposing">Specifies whether the object is in the process of disposing or not.</param>
        public virtual void Dispose(bool disposing)
        {
            _isDisposed = true;
        }

        /// <summary>
        /// Writes a message with the WritingUtensil.
        /// </summary>
        /// <param name="message">The message to write with the writing utensil.</param>
        public virtual void Write(string message)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(this + " has been disposed and is no longer available.");

            Console.ResetColor();
            Console.ForegroundColor = _inkColor;
            Console.WriteLine(message);
        }
    }
}
