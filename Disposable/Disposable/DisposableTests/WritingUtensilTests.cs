using System;
using Disposable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DisposableTests
{
    [TestClass]
    public class WritingUtensilTests
    {
        [TestMethod]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void Highlighter_Disables_On_Dispose()
        {
            var highlighter = new WritingUntensil(ConsoleColor.Black);
            highlighter.Write("Hello World");
            highlighter.Dispose();
            highlighter.Write("Hello World x2 Combo");
        }
    }
}
