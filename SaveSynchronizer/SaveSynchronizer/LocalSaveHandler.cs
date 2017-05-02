using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveSynchronizer
{
    class LocalSaveHandler
    {
        private readonly Settings _settings;

        public LocalSaveHandler(Settings settings)
        {
            _settings = settings;
        }

        public Task<DateTime> GetLocalFileModifiedAsync()
        {
            //If the file does not exist, decrease the last modified time to the smallest possible, then add one tick to the default value for unit testing.
            return Task.Run(() => File.Exists(_settings.SaveFilePath) ? File.GetLastWriteTime(_settings.SaveFilePath) : DateTime.MinValue.AddTicks(1));
        }

    }
}
