using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SaveSynchronizer
{
    /// <summary>
    /// A form dedicated to asking the user if they would like to overwrite the remote file with their current local version.
    /// </summary>
    public partial class OverwritePermissionForm : Form
    {
        private SaveSynchronizer _saveSynchronizer;
        public OverwritePermissionForm()
        {
            InitializeComponent();
        }

        public OverwritePermissionForm(SaveSynchronizer saveSynchronizer)
        {
            InitializeComponent();
            _saveSynchronizer = saveSynchronizer;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            ValidateResponse();
        }

        /// <summary>
        /// Validates the user input with regex and closes the form if valid.
        /// </summary>
        public void ValidateResponse()
        {
            bool isYes = Regex.IsMatch(entryTextBox.Text, "^(([Yy]{1}[Ee]{1}[Ss]{1})|Overwrite)[!]?$");
            bool isNo = Regex.IsMatch(entryTextBox.Text, "^(([Nn]{1}[Oo]{1})|Download)[!]?$");

            //No Regex Match
            if (!isYes && !isNo)
            {
                invalidEntryLabel.Visible = true;
                return;
            }

            //User chose to overwrite remote save.
            if (isYes)
            {
                _saveSynchronizer.OverwriteRemoteSave = true;
            }

            //Close this form. If the user did not ask to overwrite, the application will default to downloading.
            this.Close();
        }
    }
}
