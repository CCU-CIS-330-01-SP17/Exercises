using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            // Set the file name and get the output directory
            var fileName = "Test" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".xls";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // Create the file using the FileInfo object
            var file = new FileInfo(path + "\\" + fileName).Create();
            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sales list - " + DateTime.Now.ToShortDateString());
                ExcelWorksheet worksheet1 = package.Workbook.Worksheets.Add("Sample Text!");
                // --------- Data and styling goes here -------------- //
            }
        }

        /// <summary>
        /// This method handles the drag effects into the winform by giving it a "Copy" effect.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// This method changes the panel color to green and changes the panel label to the file path of the dropped file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                if (filePaths.Length == 1)
                {
                    foreach(string fileLoc in filePaths)
                    {
                        if (sender == terminatedLeasesPanel)
                        {
                            terminatedLeasesLabel.Text = fileLoc;
                            terminatedLeasesPanel.BackColor = Color.Green;
                        }
                        if (sender == newLeasesPanel)
                        {
                            newLeasesLabel.Text = fileLoc;
                            newLeasesPanel.BackColor = Color.Green;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please drag and drop only one file at a time.");
                }
            }
        }
    }
}
