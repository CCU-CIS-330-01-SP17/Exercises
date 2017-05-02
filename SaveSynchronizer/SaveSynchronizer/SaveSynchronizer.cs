using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveSynchronizer
{
    /// <summary>
    /// Checks if a local file is newer or older than a remote file and synchronizes accordingly.
    /// </summary>
    public class SaveSynchronizer
    {
        private readonly IRemoteSaveHandler _remoteSaveHandler;
        private readonly LocalSaveHandler _localSaveHandler;
        private readonly Settings _settings;

        /// <summary>
        /// Whether or not the local save overwrites the remote save in the event of a conflict.
        /// </summary>
        public bool OverwriteRemoteSave { get; set; }

        public SaveSynchronizer(IRemoteSaveHandler remoteSaveHandler)
        {
            _settings = new Settings();
            _settings.Load("settings.sav");
            _remoteSaveHandler = remoteSaveHandler;
            _localSaveHandler = new LocalSaveHandler(_settings);
        }

        /// <summary>
        /// Synchronizes a local file with a remote file by uploading or downloading as nessesary, then launches the related application.
        /// </summary>
        public void SyncAndLaunch()
        {
            //Check if Remote or Local is latest
            if (RemoteFileIsLatest())
            {
                //Download Latest
                _remoteSaveHandler.TryGetSave(_settings.SaveFilePath);
            }
            else
            {
                AskUserIfOverwrite();
                if (OverwriteRemoteSave)
                {
                    //Upload Latest
                    _remoteSaveHandler.TryStoreSave(_settings.SaveFilePath);
                }
                else
                {
                    _remoteSaveHandler.TryGetSave(_settings.SaveFilePath);
                }
            }

            //Get Hash of the latest.
            string lastRemoteHash = _remoteSaveHandler.TryGetHash();

            //Run Application and wait until close.
            ApplicationExecutor.ExecuteAndWaitUntilTerminate(_settings.ExecutablePath, _settings.Arguments);

            //Check if newer save has been uploaded in the meantime.
            Task.WaitAll(_remoteSaveHandler.GetLastSaveModifiedAsync());
            string currentRemotHash = _remoteSaveHandler.TryGetHash();

            if (lastRemoteHash != currentRemotHash)
            {
                OverwriteRemoteSave = false;
                AskUserIfOverwrite();
                if (!OverwriteRemoteSave)
                {
                    //The file should not be uploaded. Return.
                    return;
                }
            }

            //Upload Now-Modified File
            _remoteSaveHandler.TryStoreSave(_settings.SaveFilePath);
        }

        /// <summary>
        /// Verifies if the remote file is more recent than the local file.
        /// </summary>
        /// <returns>Whether the remote file is more recent than the local file.</returns>
        public bool RemoteFileIsLatest()
        {
            var remoteTask = _remoteSaveHandler.GetLastSaveModifiedAsync();
            var localTask = _localSaveHandler.GetLastSaveModifiedAsync();
            Task.WaitAll(remoteTask, localTask);
            int result = DateTime.Compare(localTask.Result, remoteTask.Result);
            return result <= 0;
        }

        /// <summary>
        /// Creates a form asking the user if they would like to overwrite the remote file with the local file.
        /// </summary>
        public void AskUserIfOverwrite()
        {
            var overwritePermissionForm = new OverwritePermissionForm(this);
            Application.Run(overwritePermissionForm);
        }
    }
}
