using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SaveSynchronizerTests
{
    [TestClass]
    public class SaveSynchronizerTests
    {
        [TestMethod]
        public void Should_Download_When_Remote_Is_Newer()
        {
            var saveSynchronizer = new SaveSynchronizer.SaveSynchronizer(new TestRemoteSaveHandler(DateTime.MaxValue));
            Assert.IsTrue(saveSynchronizer.RemoteFileIsLatest());
        }

        [TestMethod]
        public void Should_Download_When_Remote_Is_Same()
        {
            var saveSynchronizer = new SaveSynchronizer.SaveSynchronizer(new TestRemoteSaveHandler(DateTime.MinValue.AddTicks(1)));
            Assert.IsTrue(saveSynchronizer.RemoteFileIsLatest());
        }

        [TestMethod]
        public void Should_Inquire_When_Remote_Is_Older()
        {
            var saveSynchronizer = new SaveSynchronizer.SaveSynchronizer(new TestRemoteSaveHandler(DateTime.MinValue));
            Assert.IsFalse(saveSynchronizer.RemoteFileIsLatest());
        }
    }
}
