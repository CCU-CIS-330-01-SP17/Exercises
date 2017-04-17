using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disposable
{
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
        /// Whether messages written should also be highlighted.
        /// </summary>
        public bool HighlightMessages { get; set; }

        /// <summary>
        /// Writes a message with the highlighter.
        /// </summary>
        /// <param name="message">The message that should be written.</param>
        public override void Write(string message)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(this + " has been disposed and is no longer available.");

            Console.ResetColor();
            if (HighlightMessages)
                Console.BackgroundColor = _highlightColor;
            Console.ForegroundColor = _inkColor;
            Console.WriteLine(message);
        }
    }
}
