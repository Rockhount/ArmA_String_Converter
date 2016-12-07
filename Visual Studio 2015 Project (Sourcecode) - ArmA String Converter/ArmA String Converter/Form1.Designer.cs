namespace ArmA_String_Converter
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.Step3Box = new System.Windows.Forms.GroupBox();
            this.WholeWordCheckBox = new System.Windows.Forms.CheckBox();
            this.ActionBox = new System.Windows.Forms.ListBox();
            this.CaseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.Step1Box = new System.Windows.Forms.GroupBox();
            this.FolderBrowse = new System.Windows.Forms.Button();
            this.FolderPathBox = new System.Windows.Forms.TextBox();
            this.FileBrowse = new System.Windows.Forms.Button();
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.FileLabel = new System.Windows.Forms.Label();
            this.FolderLabel = new System.Windows.Forms.Label();
            this.Step2Box = new System.Windows.Forms.GroupBox();
            this.DownloadSourceButton = new System.Windows.Forms.Button();
            this.NewStringTextBox = new System.Windows.Forms.TextBox();
            this.OldStringTextBox = new System.Windows.Forms.TextBox();
            this.NewStringLabel = new System.Windows.Forms.Label();
            this.OldStringLabel = new System.Windows.Forms.Label();
            this.SourceBrowse = new System.Windows.Forms.Button();
            this.SourceFilePathBox = new System.Windows.Forms.TextBox();
            this.SourceLabel = new System.Windows.Forms.Label();
            this.Step3Box.SuspendLayout();
            this.Step1Box.SuspendLayout();
            this.Step2Box.SuspendLayout();
            this.SuspendLayout();
            // 
            // Step3Box
            // 
            this.Step3Box.Controls.Add(this.WholeWordCheckBox);
            this.Step3Box.Controls.Add(this.ActionBox);
            this.Step3Box.Controls.Add(this.CaseSensitiveCheckBox);
            this.Step3Box.Controls.Add(this.ProgressBar1);
            this.Step3Box.Controls.Add(this.ConvertButton);
            this.Step3Box.Location = new System.Drawing.Point(14, 248);
            this.Step3Box.Name = "Step3Box";
            this.Step3Box.Size = new System.Drawing.Size(487, 161);
            this.Step3Box.TabIndex = 7;
            this.Step3Box.TabStop = false;
            this.Step3Box.Text = "3. Convert";
            // 
            // WholeWordCheckBox
            // 
            this.WholeWordCheckBox.AutoSize = true;
            this.WholeWordCheckBox.Checked = true;
            this.WholeWordCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WholeWordCheckBox.Location = new System.Drawing.Point(10, 139);
            this.WholeWordCheckBox.Name = "WholeWordCheckBox";
            this.WholeWordCheckBox.Size = new System.Drawing.Size(102, 17);
            this.WholeWordCheckBox.TabIndex = 7;
            this.WholeWordCheckBox.Text = "whole word only";
            this.WholeWordCheckBox.UseVisualStyleBackColor = true;
            this.WholeWordCheckBox.CheckedChanged += new System.EventHandler(this.WholeWordCheckBox_CheckedChanged);
            // 
            // ActionBox
            // 
            this.ActionBox.FormattingEnabled = true;
            this.ActionBox.HorizontalScrollbar = true;
            this.ActionBox.Location = new System.Drawing.Point(10, 20);
            this.ActionBox.Name = "ActionBox";
            this.ActionBox.Size = new System.Drawing.Size(467, 82);
            this.ActionBox.TabIndex = 8;
            this.ActionBox.TabStop = false;
            // 
            // CaseSensitiveCheckBox
            // 
            this.CaseSensitiveCheckBox.AutoSize = true;
            this.CaseSensitiveCheckBox.Location = new System.Drawing.Point(10, 122);
            this.CaseSensitiveCheckBox.Name = "CaseSensitiveCheckBox";
            this.CaseSensitiveCheckBox.Size = new System.Drawing.Size(142, 17);
            this.CaseSensitiveCheckBox.TabIndex = 6;
            this.CaseSensitiveCheckBox.Text = "case sensitive (2x faster)";
            this.CaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            this.CaseSensitiveCheckBox.CheckedChanged += new System.EventHandler(this.CaseSensitiveBox_CheckedChanged);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(10, 106);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(467, 13);
            this.ProgressBar1.TabIndex = 2;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Enabled = false;
            this.ConvertButton.Location = new System.Drawing.Point(270, 128);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(97, 23);
            this.ConvertButton.TabIndex = 8;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // Step1Box
            // 
            this.Step1Box.Controls.Add(this.FolderBrowse);
            this.Step1Box.Controls.Add(this.FolderPathBox);
            this.Step1Box.Controls.Add(this.FileBrowse);
            this.Step1Box.Controls.Add(this.FilePathBox);
            this.Step1Box.Controls.Add(this.FileLabel);
            this.Step1Box.Controls.Add(this.FolderLabel);
            this.Step1Box.Location = new System.Drawing.Point(14, 12);
            this.Step1Box.Name = "Step1Box";
            this.Step1Box.Size = new System.Drawing.Size(487, 107);
            this.Step1Box.TabIndex = 5;
            this.Step1Box.TabStop = false;
            this.Step1Box.Text = "1. Select a file or folder";
            // 
            // FolderBrowse
            // 
            this.FolderBrowse.Location = new System.Drawing.Point(395, 76);
            this.FolderBrowse.Name = "FolderBrowse";
            this.FolderBrowse.Size = new System.Drawing.Size(83, 23);
            this.FolderBrowse.TabIndex = 1;
            this.FolderBrowse.Text = "Browse";
            this.FolderBrowse.UseVisualStyleBackColor = true;
            this.FolderBrowse.Click += new System.EventHandler(this.FolderBrowse_Click);
            // 
            // FolderPathBox
            // 
            this.FolderPathBox.BackColor = System.Drawing.Color.White;
            this.FolderPathBox.Location = new System.Drawing.Point(9, 77);
            this.FolderPathBox.Name = "FolderPathBox";
            this.FolderPathBox.ReadOnly = true;
            this.FolderPathBox.Size = new System.Drawing.Size(380, 20);
            this.FolderPathBox.TabIndex = 2;
            this.FolderPathBox.TabStop = false;
            this.FolderPathBox.TextChanged += new System.EventHandler(this.FolderPathBox_TextChanged);
            // 
            // FileBrowse
            // 
            this.FileBrowse.Location = new System.Drawing.Point(395, 32);
            this.FileBrowse.Name = "FileBrowse";
            this.FileBrowse.Size = new System.Drawing.Size(83, 23);
            this.FileBrowse.TabIndex = 0;
            this.FileBrowse.Text = "Browse";
            this.FileBrowse.UseVisualStyleBackColor = true;
            this.FileBrowse.Click += new System.EventHandler(this.FileBrowse_Click);
            // 
            // FilePathBox
            // 
            this.FilePathBox.BackColor = System.Drawing.Color.White;
            this.FilePathBox.Location = new System.Drawing.Point(9, 33);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.ReadOnly = true;
            this.FilePathBox.Size = new System.Drawing.Size(380, 20);
            this.FilePathBox.TabIndex = 0;
            this.FilePathBox.TabStop = false;
            this.FilePathBox.TextChanged += new System.EventHandler(this.FilePathBox_TextChanged);
            // 
            // FileLabel
            // 
            this.FileLabel.AutoSize = true;
            this.FileLabel.Location = new System.Drawing.Point(6, 16);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(23, 13);
            this.FileLabel.TabIndex = 0;
            this.FileLabel.Text = "File";
            // 
            // FolderLabel
            // 
            this.FolderLabel.AutoSize = true;
            this.FolderLabel.Location = new System.Drawing.Point(6, 61);
            this.FolderLabel.Name = "FolderLabel";
            this.FolderLabel.Size = new System.Drawing.Size(36, 13);
            this.FolderLabel.TabIndex = 1;
            this.FolderLabel.Text = "Folder";
            // 
            // Step2Box
            // 
            this.Step2Box.Controls.Add(this.DownloadSourceButton);
            this.Step2Box.Controls.Add(this.NewStringTextBox);
            this.Step2Box.Controls.Add(this.OldStringTextBox);
            this.Step2Box.Controls.Add(this.NewStringLabel);
            this.Step2Box.Controls.Add(this.OldStringLabel);
            this.Step2Box.Controls.Add(this.SourceBrowse);
            this.Step2Box.Controls.Add(this.SourceFilePathBox);
            this.Step2Box.Controls.Add(this.SourceLabel);
            this.Step2Box.Location = new System.Drawing.Point(14, 125);
            this.Step2Box.Name = "Step2Box";
            this.Step2Box.Size = new System.Drawing.Size(487, 117);
            this.Step2Box.TabIndex = 6;
            this.Step2Box.TabStop = false;
            this.Step2Box.Text = "2. Select Beerkan\'s \"ChangeText\" file or write it directly";
            // 
            // DownloadSourceButton
            // 
            this.DownloadSourceButton.Location = new System.Drawing.Point(395, 36);
            this.DownloadSourceButton.Name = "DownloadSourceButton";
            this.DownloadSourceButton.Size = new System.Drawing.Size(83, 23);
            this.DownloadSourceButton.TabIndex = 3;
            this.DownloadSourceButton.Text = "Download";
            this.DownloadSourceButton.UseVisualStyleBackColor = true;
            this.DownloadSourceButton.Click += new System.EventHandler(this.DownloadSourceButton_Click);
            // 
            // NewStringTextBox
            // 
            this.NewStringTextBox.Location = new System.Drawing.Point(246, 82);
            this.NewStringTextBox.Name = "NewStringTextBox";
            this.NewStringTextBox.Size = new System.Drawing.Size(232, 20);
            this.NewStringTextBox.TabIndex = 5;
            this.NewStringTextBox.TextChanged += new System.EventHandler(this.NewStringText_TextChanged);
            // 
            // OldStringTextBox
            // 
            this.OldStringTextBox.Location = new System.Drawing.Point(9, 82);
            this.OldStringTextBox.Name = "OldStringTextBox";
            this.OldStringTextBox.Size = new System.Drawing.Size(231, 20);
            this.OldStringTextBox.TabIndex = 4;
            this.OldStringTextBox.TextChanged += new System.EventHandler(this.OldStringText_TextChanged);
            // 
            // NewStringLabel
            // 
            this.NewStringLabel.AutoSize = true;
            this.NewStringLabel.Location = new System.Drawing.Point(243, 65);
            this.NewStringLabel.Name = "NewStringLabel";
            this.NewStringLabel.Size = new System.Drawing.Size(49, 13);
            this.NewStringLabel.TabIndex = 10;
            this.NewStringLabel.Text = "New text";
            // 
            // OldStringLabel
            // 
            this.OldStringLabel.AutoSize = true;
            this.OldStringLabel.Location = new System.Drawing.Point(6, 65);
            this.OldStringLabel.Name = "OldStringLabel";
            this.OldStringLabel.Size = new System.Drawing.Size(43, 13);
            this.OldStringLabel.TabIndex = 9;
            this.OldStringLabel.Text = "Old text";
            // 
            // SourceBrowse
            // 
            this.SourceBrowse.Location = new System.Drawing.Point(303, 36);
            this.SourceBrowse.Name = "SourceBrowse";
            this.SourceBrowse.Size = new System.Drawing.Size(86, 23);
            this.SourceBrowse.TabIndex = 2;
            this.SourceBrowse.Text = "Browse";
            this.SourceBrowse.UseVisualStyleBackColor = true;
            this.SourceBrowse.Click += new System.EventHandler(this.SourceBrowse_Click);
            // 
            // SourceFilePathBox
            // 
            this.SourceFilePathBox.BackColor = System.Drawing.Color.White;
            this.SourceFilePathBox.Location = new System.Drawing.Point(9, 38);
            this.SourceFilePathBox.Name = "SourceFilePathBox";
            this.SourceFilePathBox.ReadOnly = true;
            this.SourceFilePathBox.Size = new System.Drawing.Size(288, 20);
            this.SourceFilePathBox.TabIndex = 7;
            this.SourceFilePathBox.TabStop = false;
            this.SourceFilePathBox.TextChanged += new System.EventHandler(this.SourceFilePathBox_TextChanged);
            // 
            // SourceLabel
            // 
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.Location = new System.Drawing.Point(6, 22);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(141, 13);
            this.SourceLabel.TabIndex = 6;
            this.SourceLabel.Text = "Beerkan\'s \"ChangeText\" file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(514, 421);
            this.Controls.Add(this.Step3Box);
            this.Controls.Add(this.Step1Box);
            this.Controls.Add(this.Step2Box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ArmA String Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Step3Box.ResumeLayout(false);
            this.Step3Box.PerformLayout();
            this.Step1Box.ResumeLayout(false);
            this.Step1Box.PerformLayout();
            this.Step2Box.ResumeLayout(false);
            this.Step2Box.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Step3Box;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.GroupBox Step1Box;
        private System.Windows.Forms.Button FolderBrowse;
        private System.Windows.Forms.TextBox FolderPathBox;
        private System.Windows.Forms.Button FileBrowse;
        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.Label FolderLabel;
        private System.Windows.Forms.GroupBox Step2Box;
        private System.Windows.Forms.TextBox NewStringTextBox;
        private System.Windows.Forms.TextBox OldStringTextBox;
        private System.Windows.Forms.Label NewStringLabel;
        private System.Windows.Forms.Label OldStringLabel;
        private System.Windows.Forms.Button SourceBrowse;
        private System.Windows.Forms.TextBox SourceFilePathBox;
        private System.Windows.Forms.Label SourceLabel;
        private System.Windows.Forms.CheckBox CaseSensitiveCheckBox;
        private System.Windows.Forms.Button DownloadSourceButton;
        private System.Windows.Forms.ListBox ActionBox;
        private System.Windows.Forms.CheckBox WholeWordCheckBox;
    }
}

