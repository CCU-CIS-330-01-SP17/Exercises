using System.IO;
using System.Web.Script.Serialization;

namespace SaveSynchronizer
{
    /// <summary>
    /// Contains the application's settings.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// The filepath to the file to be synchronized.
        /// </summary>
        public string SaveFilePath { get; set; }

        /// <summary>
        /// The filepath to the executable to be run after synchronization, after which to resynchronize.
        /// </summary>
        public string ExecutablePath { get; set; }

        /// <summary>
        /// The arguments with which to launch the Executable.
        /// </summary>
        public string Arguments { get; set; }

        public Settings()
        {
            //Instantiate default property values.
            SaveFilePath = Path.GetFullPath("TestFile.txt");
            ExecutablePath = @"C:\Windows\System32\Notepad.exe";
            Arguments = SaveFilePath;
        }

        /// <summary>
        /// Deserialized the saved settings file and loads the values into this object. If one does not exist, load the defaults and create the file.
        /// </summary>
        /// <param name="path">The FilePath to the saved settings file on disk.</param>
        public void Load(string path)
        {
            if (File.Exists(path))
            {
                //The settings file exists. Load it.
                string json = File.ReadAllText(path);
                var newSettings = new JavaScriptSerializer().Deserialize<Settings>(json);
                this.ExecutablePath = newSettings.ExecutablePath;
                this.SaveFilePath = newSettings.SaveFilePath;
            }
            else
            {
                //The settings file does not exist. Save a default settings file.
                var theseSettings = new JavaScriptSerializer().Serialize(this);
                File.WriteAllText(path, theseSettings);
            }
        }
    }
}
