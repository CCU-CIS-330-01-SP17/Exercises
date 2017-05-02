using System.Diagnostics;

namespace SaveSynchronizer
{
    /// <summary>
    /// Runs a specified application.
    /// </summary>
    public static class ApplicationExecutor
    {
        /// <summary>
        /// Runs an executable file and returns once it has been closed.
        /// </summary>
        /// <param name="executableFilePath">The path to the file to be executed.</param>
        /// <param name="arguments">Command line arguments to use when executing the file.</param>
        public static void ExecuteAndWaitUntilTerminate(string executableFilePath, string arguments = null)
        {
            var info = new ProcessStartInfo(executableFilePath);
            if (arguments != null)
                info.Arguments = arguments;
            Process gameProcess = Process.Start(info);
            gameProcess?.WaitForExit();
        }
    }
}
