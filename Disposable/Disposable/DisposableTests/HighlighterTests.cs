using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Disposable;

namespace DisposableTests
{
    [TestClass]
    public class HighlighterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void Highlighter_Disables_On_Dispose()
        {
            var highlighter = new Highlighter(ConsoleColor.Black, ConsoleColor.Yellow);
            highlighter.Write("Hello World");
            highlighter.Dispose();
            highlighter.Write("Hello World x2 Combo");
        }
    }
}
