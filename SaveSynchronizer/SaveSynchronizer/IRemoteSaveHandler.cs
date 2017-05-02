using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SaveSynchronizer
{
    /// <summary>
    /// Used to interface with a class that handles the synchronization of remote files.
    /// </summary>
    public interface IRemoteSaveHandler
    {
        /// <summary>
        /// The DateTime of the last time the remote save was modified.
        /// </summary>
        Task<DateTime> GetLastSaveModifiedAsync();

        /// <summary>
        /// Attempt to obtain the remote save.
        /// </summary>
        /// <param name="saveFilePath">The path to which the save will be downloaded.</param>
        /// <returns>Whether or not the save was sucessfully obtained.</returns>
        bool TryGetSave(string saveFilePath);

        /// <summary>
        /// Attempt to upload the local save.
        /// </summary>
        /// <param name="uploadFilePath">The filepath of the save to be uploaded.</param>
        /// <returns>Whether or not the save was sucessfully sent.</returns>
        bool TryStoreSave(string uploadFilePath);

        /// <summary>
        /// Attempt to obtain the hash of the most recent save.
        /// </summary>
        /// <returns>The unique hash of the most recent save.</returns>
        string TryGetHash();
    }
}
