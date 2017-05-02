using System;
using System.Windows.Forms;

namespace SaveSynchronizer
{
    /// <summary>
    /// The Class that serves as the main entry point.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Create a new SaveSynchronizer with an auth-based FTP remote.
            var saveSynchronizer = new SaveSynchronizer(new FTPSaveHandler("falchion", "DunDef", "dundef"));
            saveSynchronizer.SyncAndLaunch();
        }
    }
}
