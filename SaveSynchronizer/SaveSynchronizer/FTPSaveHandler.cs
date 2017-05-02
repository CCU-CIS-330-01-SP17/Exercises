using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentFTP;

namespace SaveSynchronizer
{
    /// <summary>
    /// Uses FTP to manage the latest save file, allowing uploads and downloads of it.
    /// </summary>
    class FTPSaveHandler: IRemoteSaveHandler
    {
        private FtpClient _ftpClient;
        private string _host;
        private string _user;
        private string _password;
        /// <summary>
        /// The FtpListItem of the last uploaded file.
        /// </summary>
        public FtpListItem LastSave { get; private set; }

        /// <summary>
        /// Creates a new FTPSaveHandler.
        /// </summary>
        /// <param name="host">The host which should be connected to.</param>
        /// <param name="user">The username with which to authenticate.</param>
        /// <param name="password">The password with which to authenticate.</param>
        public FTPSaveHandler(string host, string user, string password)
        {
            _host = host;
            _user = user;
            _password = password;
        }

        /// <summary>
        /// The upload DateTime of the latest uploaded file.
        /// </summary>
        public Task<DateTime> GetLastSaveModifiedAsync()
        {
            return Task.Run(() =>
             {
                 GetSaveInfo();
                 return LastSave.Modified;
             });
        }

        /// <summary>
        /// Creates a new FTPClient so as prevent accidental timeout.
        /// </summary>
        private void RenewClient()
        {
            _ftpClient?.Disconnect();
            _ftpClient = new FtpClient() { Host = _host, Credentials = new NetworkCredential(_user, _password) };
        }

        /// <summary>
        /// Contacts the FTPServer and finds the Save last uploaded.
        /// </summary>
        /// <returns>The FTPListItem of the latest file uploaded.</returns>
        private void GetSaveInfo()
        {
            RenewClient();
            _ftpClient.SetWorkingDirectory("/Final");
            //Retrieve the list of all saves, then get the most recently modified.
            var allSaves = _ftpClient.GetListing();
            var latestSave = allSaves.OrderByDescending(save => save.Modified).First();
            LastSave = latestSave;
        }

        /// <summary>
        /// Attempts to download the latest save into a specified directory.
        /// </summary>
        /// <param name="saveFilePath">The filepath on the local machine into which the file should be downloaded.</param>
        /// <returns>Whether download was successful or a failure in boolean format.</returns>
        public bool TryGetSave(string saveFilePath)
        {
            try
            {
                RenewClient();
                _ftpClient.DownloadFile(Path.GetFullPath(saveFilePath), LastSave.FullName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            return true;
        }

        /// <summary>
        /// Attempts to upload a save on the local machine from the specified filelocation.
        /// </summary>
        /// <param name="uploadFilePath">The filepath of the file to be uploaded.</param>
        /// <returns>Whether upload was successful or a failure in boolean format.</returns>
        public bool TryStoreSave(string uploadFilePath)
        {
            try
            {
                RenewClient();
                var ftpLocation = @"\Final\" + DateTime.Now.ToString().Replace('/', '-').Replace(':', '_') + ".bak";
                _ftpClient.UploadFile(uploadFilePath, ftpLocation, false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            return true;
        }

        /// <summary>
        /// Gets the SHA512 hash for the last save.
        /// </summary>
        /// <returns>The SHA512 hash of the last save in string form.</returns>
        public string TryGetHash()
        {
            string hash;
            try
            {
                RenewClient();
                _ftpClient.SetHashAlgorithm(FtpHashAlgorithm.SHA512);
                hash = _ftpClient.GetHash(LastSave.FullName).Value;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return hash;
        }
    }
}
