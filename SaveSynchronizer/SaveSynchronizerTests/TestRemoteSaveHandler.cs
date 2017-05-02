using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveSynchronizer;

namespace SaveSynchronizerTests
{
    /// <summary>
    /// A stub implementation of IRemoteSaveHandler for testing RemoteFileIsLatest in SaveSynchronizer.cs
    /// </summary>
    class TestRemoteSaveHandler : IRemoteSaveHandler
    {
        private readonly DateTime _lastModifiedTime;

        public TestRemoteSaveHandler(DateTime lastModifiedTime)
        {
            _lastModifiedTime = lastModifiedTime;
        }

        public Task<DateTime> GetLastSaveModifiedAsync()
        {
            return Task.Run(() => _lastModifiedTime);
        }

        //Not implemented because tests will never call.
        public bool TryGetSave(string saveFilePath)
        {
            throw new NotImplementedException();
        }

        public bool TryStoreSave(string uploadFilePath)
        {
            throw new NotImplementedException();
        }

        public string TryGetHash()
        {
            throw new NotImplementedException();
        }
    }
}
