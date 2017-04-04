using System.Windows.Forms;

namespace FinalProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.goButton = new System.Windows.Forms.Button();
            this.terminatedLeasesPanel = new System.Windows.Forms.Panel();
            this.terminatedLeasesLabel = new System.Windows.Forms.Label();
            this.newLeasesPanel = new System.Windows.Forms.Panel();
            this.newLeasesLabel = new System.Windows.Forms.Label();
            this.terminatedLeasesPanel.SuspendLayout();
            this.newLeasesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(519, 289);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(84, 30);
            this.goButton.TabIndex = 0;
            this.goButton.Text = "Go!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // terminatedLeasesPanel
            // 
            this.terminatedLeasesPanel.AllowDrop = true;
            this.terminatedLeasesPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.terminatedLeasesPanel.Controls.Add(this.terminatedLeasesLabel);
            this.terminatedLeasesPanel.Location = new System.Drawing.Point(37, 120);
            this.terminatedLeasesPanel.Name = "terminatedLeasesPanel";
            this.terminatedLeasesPanel.Size = new System.Drawing.Size(250, 100);
            this.terminatedLeasesPanel.TabIndex = 1;
            this.terminatedLeasesPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.terminatedLeasesPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // terminatedLeasesLabel
            // 
            this.terminatedLeasesLabel.AutoSize = true;
            this.terminatedLeasesLabel.Location = new System.Drawing.Point(3, 39);
            this.terminatedLeasesLabel.Name = "terminatedLeasesLabel";
            this.terminatedLeasesLabel.Size = new System.Drawing.Size(135, 13);
            this.terminatedLeasesLabel.TabIndex = 0;
            this.terminatedLeasesLabel.Text = "Termintated Leases Report";
            // 
            // newLeasesPanel
            // 
            this.newLeasesPanel.AllowDrop = true;
            this.newLeasesPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.newLeasesPanel.Controls.Add(this.newLeasesLabel);
            this.newLeasesPanel.Location = new System.Drawing.Point(293, 120);
            this.newLeasesPanel.Name = "newLeasesPanel";
            this.newLeasesPanel.Size = new System.Drawing.Size(250, 100);
            this.newLeasesPanel.TabIndex = 2;
            this.newLeasesPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.newLeasesPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // newLeasesLabel
            // 
            this.newLeasesLabel.AutoSize = true;
            this.newLeasesLabel.Location = new System.Drawing.Point(3, 39);
            this.newLeasesLabel.Name = "newLeasesLabel";
            this.newLeasesLabel.Size = new System.Drawing.Size(101, 13);
            this.newLeasesLabel.TabIndex = 0;
            this.newLeasesLabel.Text = "New Leases Report";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 331);
            this.Controls.Add(this.newLeasesPanel);
            this.Controls.Add(this.terminatedLeasesPanel);
            this.Controls.Add(this.goButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.terminatedLeasesPanel.ResumeLayout(false);
            this.terminatedLeasesPanel.PerformLayout();
            this.newLeasesPanel.ResumeLayout(false);
            this.newLeasesPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Panel terminatedLeasesPanel;
        private System.Windows.Forms.Panel newLeasesPanel;
        private System.Windows.Forms.Label terminatedLeasesLabel;
        private System.Windows.Forms.Label newLeasesLabel;
    }
}

