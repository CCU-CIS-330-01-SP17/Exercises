using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disposable
{
    /// <summary>
    /// A Writing Utensil, ususally used to draw attention to existing words.
    /// </summary>
    public class Highlighter : WritingUntensil
    {
        private bool _isDisposed;
        private readonly ConsoleColor _highlightColor;
        private readonly ConsoleColor _inkColor;

        public Highlighter(ConsoleColor inkColor, ConsoleColor highlightColor) : base(inkColor)
        {
            _highlightColor = highlightColor;
            _inkColor = inkColor;
            _isDisposed = false;
        }

        /// <summary>
        /// Readies the Highlighter for disposal.
        /// </summary>
        public new void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Readies the Highlighter for disposal and disables functionality.
        /// </summary>
        /// <param name="disposing">Specifies whether the object is in the process of disposing or not.</param>
        internal override void Dispose(bool disposing)
        {
            _isDisposed = true;
            base.Dispose(disposing);
        }

        /// <summary>
        /// Writes a message with the highlighter.
        /// </summary>
        /// <param name="message">The message that should be written.</param>
        public override void Write(string message)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(this + " has been disposed and is no longer available.");

            Console.ResetColor();
            Console.BackgroundColor = _highlightColor;
            Console.ForegroundColor = _inkColor;
            Console.WriteLine(message);
        }
    }
}
