using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaveSynchronizer;

namespace SaveSynchronizerTests
{
    [TestClass]
    public class OverwritePermissionFormTests
    {
        [TestMethod]
        public void Form_Accepts_Mixed_Case()
        {
            var saveSynchronizer = new SaveSynchronizer.SaveSynchronizer(new TestRemoteSaveHandler(DateTime.MaxValue));
            var overwritePermissionForm = new OverwritePermissionForm(saveSynchronizer);
            var textBox = (TextBox)overwritePermissionForm.Controls.Find("entryTextBox", true).First();
            textBox.Text = "YeS!";
            overwritePermissionForm.ValidateResponse();
            Assert.IsTrue(saveSynchronizer.OverwriteRemoteSave);
        }

        [TestMethod]
        public void Form_Will_Not_Accept_Invalid_Response()
        {
            var saveSynchronizer = new SaveSynchronizer.SaveSynchronizer(new TestRemoteSaveHandler(DateTime.MaxValue));
            var overwritePermissionForm = new OverwritePermissionForm(saveSynchronizer);
            var textBox = (TextBox)overwritePermissionForm.Controls.Find("entryTextBox", true).First();
            textBox.Text = "AppleSauce!";
            overwritePermissionForm.ValidateResponse();
            Assert.IsFalse(saveSynchronizer.OverwriteRemoteSave);
        }

        [TestMethod]
        public void Form_Accepts_No_Exclamation()
        {
            var saveSynchronizer = new SaveSynchronizer.SaveSynchronizer(new TestRemoteSaveHandler(DateTime.MaxValue));
            var overwritePermissionForm = new OverwritePermissionForm(saveSynchronizer);
            var textBox = (TextBox)overwritePermissionForm.Controls.Find("entryTextBox", true).First();
            textBox.Text = "No";
            overwritePermissionForm.ValidateResponse();
            Assert.IsFalse(saveSynchronizer.OverwriteRemoteSave);
        }
    }
}
