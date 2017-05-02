namespace SaveSynchronizer
{
    partial class OverwritePermissionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.entryTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.invalidEntryLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A more recent local save was detected. Would you like to use it as the latest? Pl" +
    "ease enter \"Yes\" or \"No\".";
            // 
            // entryTextBox
            // 
            this.entryTextBox.Location = new System.Drawing.Point(45, 42);
            this.entryTextBox.Name = "entryTextBox";
            this.entryTextBox.Size = new System.Drawing.Size(412, 20);
            this.entryTextBox.TabIndex = 1;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(463, 40);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(87, 23);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // invalidEntryLabel
            // 
            this.invalidEntryLabel.AutoSize = true;
            this.invalidEntryLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidEntryLabel.Location = new System.Drawing.Point(53, 65);
            this.invalidEntryLabel.Name = "invalidEntryLabel";
            this.invalidEntryLabel.Size = new System.Drawing.Size(65, 13);
            this.invalidEntryLabel.TabIndex = 3;
            this.invalidEntryLabel.Text = "Invalid Entry";
            this.invalidEntryLabel.Visible = false;
            // 
            // OverwritePermissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 100);
            this.Controls.Add(this.invalidEntryLabel);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.entryTextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OverwritePermissionForm";
            this.Text = "More Recent Local Save Detected";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label invalidEntryLabel;
        private System.Windows.Forms.TextBox entryTextBox;
    }
}

