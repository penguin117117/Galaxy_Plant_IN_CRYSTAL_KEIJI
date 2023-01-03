namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI
{
    partial class IODebugForm
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
            this.Yaz0Dec = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Yaz0GroupBox = new System.Windows.Forms.GroupBox();
            this.Yaz0EncButton = new System.Windows.Forms.Button();
            this.Yaz0FilePathLabel = new System.Windows.Forms.Label();
            this.Yaz0DecRARCExtDirectoryButton = new System.Windows.Forms.Button();
            this.RARCDecComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusTextToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.RARCStatusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.RARCInFilesComboBox = new System.Windows.Forms.ComboBox();
            this.RARCInFileBinaryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RARCGroupBox = new System.Windows.Forms.GroupBox();
            this.ProjectDirectoryComboBox = new System.Windows.Forms.ComboBox();
            this.RARCExtDirectoryButton = new System.Windows.Forms.Button();
            this.Yaz0DecRARCExtDictionaryButton = new System.Windows.Forms.Button();
            this.RARCExtDictinaryButton = new System.Windows.Forms.Button();
            this.RARCArchiveGroupBox = new System.Windows.Forms.GroupBox();
            this.RARCArchiveCreateButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.Yaz0GroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.RARCGroupBox.SuspendLayout();
            this.RARCArchiveGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Yaz0Dec
            // 
            this.Yaz0Dec.Location = new System.Drawing.Point(6, 37);
            this.Yaz0Dec.Name = "Yaz0Dec";
            this.Yaz0Dec.Size = new System.Drawing.Size(148, 23);
            this.Yaz0Dec.TabIndex = 0;
            this.Yaz0Dec.Text = "Yaz0Dec";
            this.Yaz0Dec.UseVisualStyleBackColor = true;
            this.Yaz0Dec.Click += new System.EventHandler(this.Yaz0Dec_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(889, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // Yaz0GroupBox
            // 
            this.Yaz0GroupBox.Controls.Add(this.Yaz0EncButton);
            this.Yaz0GroupBox.Controls.Add(this.Yaz0FilePathLabel);
            this.Yaz0GroupBox.Controls.Add(this.Yaz0Dec);
            this.Yaz0GroupBox.Location = new System.Drawing.Point(12, 27);
            this.Yaz0GroupBox.Name = "Yaz0GroupBox";
            this.Yaz0GroupBox.Size = new System.Drawing.Size(418, 71);
            this.Yaz0GroupBox.TabIndex = 2;
            this.Yaz0GroupBox.TabStop = false;
            this.Yaz0GroupBox.Text = "Yaz0";
            this.Yaz0GroupBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.Yaz0GroupBox_DragDrop);
            this.Yaz0GroupBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.Yaz0GroupBox_DragEnter);
            // 
            // Yaz0EncButton
            // 
            this.Yaz0EncButton.Location = new System.Drawing.Point(160, 37);
            this.Yaz0EncButton.Name = "Yaz0EncButton";
            this.Yaz0EncButton.Size = new System.Drawing.Size(148, 23);
            this.Yaz0EncButton.TabIndex = 5;
            this.Yaz0EncButton.Text = "Yaz0Enc";
            this.Yaz0EncButton.UseVisualStyleBackColor = true;
            this.Yaz0EncButton.Click += new System.EventHandler(this.Yaz0EncButton_Click);
            // 
            // Yaz0FilePathLabel
            // 
            this.Yaz0FilePathLabel.AutoSize = true;
            this.Yaz0FilePathLabel.Location = new System.Drawing.Point(6, 19);
            this.Yaz0FilePathLabel.Name = "Yaz0FilePathLabel";
            this.Yaz0FilePathLabel.Size = new System.Drawing.Size(81, 15);
            this.Yaz0FilePathLabel.TabIndex = 3;
            this.Yaz0FilePathLabel.Text = "TargetFilePath";
            // 
            // Yaz0DecRARCExtDirectoryButton
            // 
            this.Yaz0DecRARCExtDirectoryButton.Location = new System.Drawing.Point(12, 337);
            this.Yaz0DecRARCExtDirectoryButton.Name = "Yaz0DecRARCExtDirectoryButton";
            this.Yaz0DecRARCExtDirectoryButton.Size = new System.Drawing.Size(148, 23);
            this.Yaz0DecRARCExtDirectoryButton.TabIndex = 6;
            this.Yaz0DecRARCExtDirectoryButton.Text = "Yaz0DecRARCExtDirectory";
            this.Yaz0DecRARCExtDirectoryButton.UseVisualStyleBackColor = true;
            this.Yaz0DecRARCExtDirectoryButton.Click += new System.EventHandler(this.Yaz0DecRARCExtDirectoryButton_Click);
            // 
            // RARCDecComboBox
            // 
            this.RARCDecComboBox.FormattingEnabled = true;
            this.RARCDecComboBox.Location = new System.Drawing.Point(6, 42);
            this.RARCDecComboBox.Name = "RARCDecComboBox";
            this.RARCDecComboBox.Size = new System.Drawing.Size(406, 23);
            this.RARCDecComboBox.TabIndex = 4;
            this.RARCDecComboBox.SelectedIndexChanged += new System.EventHandler(this.Yaz0DecComboBox_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusTextToolStripStatusLabel,
            this.RARCStatusToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(889, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusTextToolStripStatusLabel
            // 
            this.StatusTextToolStripStatusLabel.Name = "StatusTextToolStripStatusLabel";
            this.StatusTextToolStripStatusLabel.Size = new System.Drawing.Size(43, 17);
            this.StatusTextToolStripStatusLabel.Text = "状態：";
            // 
            // RARCStatusToolStripStatusLabel
            // 
            this.RARCStatusToolStripStatusLabel.Name = "RARCStatusToolStripStatusLabel";
            this.RARCStatusToolStripStatusLabel.Size = new System.Drawing.Size(162, 17);
            this.RARCStatusToolStripStatusLabel.Text = "ファイルが読み込まれていません。";
            // 
            // RARCInFilesComboBox
            // 
            this.RARCInFilesComboBox.FormattingEnabled = true;
            this.RARCInFilesComboBox.Location = new System.Drawing.Point(6, 22);
            this.RARCInFilesComboBox.Name = "RARCInFilesComboBox";
            this.RARCInFilesComboBox.Size = new System.Drawing.Size(394, 23);
            this.RARCInFilesComboBox.TabIndex = 9;
            this.RARCInFilesComboBox.SelectedIndexChanged += new System.EventHandler(this.RARCInFilesComboBox_SelectedIndexChanged);
            this.RARCInFilesComboBox.SelectionChangeCommitted += new System.EventHandler(this.RARCInFilesComboBox_SelectionChangeCommitted);
            // 
            // RARCInFileBinaryTextBox
            // 
            this.RARCInFileBinaryTextBox.Location = new System.Drawing.Point(6, 51);
            this.RARCInFileBinaryTextBox.Multiline = true;
            this.RARCInFileBinaryTextBox.Name = "RARCInFileBinaryTextBox";
            this.RARCInFileBinaryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RARCInFileBinaryTextBox.Size = new System.Drawing.Size(394, 340);
            this.RARCInFileBinaryTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(436, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "→";
            // 
            // RARCGroupBox
            // 
            this.RARCGroupBox.Controls.Add(this.ProjectDirectoryComboBox);
            this.RARCGroupBox.Controls.Add(this.RARCExtDirectoryButton);
            this.RARCGroupBox.Controls.Add(this.Yaz0DecRARCExtDictionaryButton);
            this.RARCGroupBox.Controls.Add(this.RARCExtDictinaryButton);
            this.RARCGroupBox.Controls.Add(this.RARCDecComboBox);
            this.RARCGroupBox.Controls.Add(this.Yaz0DecRARCExtDirectoryButton);
            this.RARCGroupBox.Location = new System.Drawing.Point(12, 104);
            this.RARCGroupBox.Name = "RARCGroupBox";
            this.RARCGroupBox.Size = new System.Drawing.Size(418, 397);
            this.RARCGroupBox.TabIndex = 12;
            this.RARCGroupBox.TabStop = false;
            this.RARCGroupBox.Text = "RARCFile";
            // 
            // ProjectDirectoryComboBox
            // 
            this.ProjectDirectoryComboBox.FormattingEnabled = true;
            this.ProjectDirectoryComboBox.Location = new System.Drawing.Point(6, 17);
            this.ProjectDirectoryComboBox.Name = "ProjectDirectoryComboBox";
            this.ProjectDirectoryComboBox.Size = new System.Drawing.Size(210, 23);
            this.ProjectDirectoryComboBox.TabIndex = 16;
            this.ProjectDirectoryComboBox.SelectedIndexChanged += new System.EventHandler(this.ProjectDirectoryComboBox_SelectedIndexChanged);
            // 
            // RARCExtDirectoryButton
            // 
            this.RARCExtDirectoryButton.Location = new System.Drawing.Point(12, 366);
            this.RARCExtDirectoryButton.Name = "RARCExtDirectoryButton";
            this.RARCExtDirectoryButton.Size = new System.Drawing.Size(148, 23);
            this.RARCExtDirectoryButton.TabIndex = 15;
            this.RARCExtDirectoryButton.Text = "RARCExtDirectory";
            this.RARCExtDirectoryButton.UseVisualStyleBackColor = true;
            this.RARCExtDirectoryButton.Click += new System.EventHandler(this.RARCExtDirectoryButton_Click);
            // 
            // Yaz0DecRARCExtDictionaryButton
            // 
            this.Yaz0DecRARCExtDictionaryButton.Location = new System.Drawing.Point(264, 337);
            this.Yaz0DecRARCExtDictionaryButton.Name = "Yaz0DecRARCExtDictionaryButton";
            this.Yaz0DecRARCExtDictionaryButton.Size = new System.Drawing.Size(148, 23);
            this.Yaz0DecRARCExtDictionaryButton.TabIndex = 14;
            this.Yaz0DecRARCExtDictionaryButton.Text = "Yaz0DecRARCExtDictionary";
            this.Yaz0DecRARCExtDictionaryButton.UseVisualStyleBackColor = true;
            this.Yaz0DecRARCExtDictionaryButton.Click += new System.EventHandler(this.Yaz0DecRARCExtDictionaryButton_Click);
            // 
            // RARCExtDictinaryButton
            // 
            this.RARCExtDictinaryButton.Location = new System.Drawing.Point(264, 366);
            this.RARCExtDictinaryButton.Name = "RARCExtDictinaryButton";
            this.RARCExtDictinaryButton.Size = new System.Drawing.Size(148, 23);
            this.RARCExtDictinaryButton.TabIndex = 13;
            this.RARCExtDictinaryButton.Text = "RARCExtDictinary";
            this.RARCExtDictinaryButton.UseVisualStyleBackColor = true;
            this.RARCExtDictinaryButton.Click += new System.EventHandler(this.RARCExtDictinaryButton_Click);
            // 
            // RARCArchiveGroupBox
            // 
            this.RARCArchiveGroupBox.Controls.Add(this.RARCInFilesComboBox);
            this.RARCArchiveGroupBox.Controls.Add(this.RARCInFileBinaryTextBox);
            this.RARCArchiveGroupBox.Location = new System.Drawing.Point(473, 104);
            this.RARCArchiveGroupBox.Name = "RARCArchiveGroupBox";
            this.RARCArchiveGroupBox.Size = new System.Drawing.Size(406, 397);
            this.RARCArchiveGroupBox.TabIndex = 12;
            this.RARCArchiveGroupBox.TabStop = false;
            this.RARCArchiveGroupBox.Text = "RARCArchive";
            // 
            // RARCArchiveCreateButton
            // 
            this.RARCArchiveCreateButton.Location = new System.Drawing.Point(473, 38);
            this.RARCArchiveCreateButton.Name = "RARCArchiveCreateButton";
            this.RARCArchiveCreateButton.Size = new System.Drawing.Size(182, 23);
            this.RARCArchiveCreateButton.TabIndex = 13;
            this.RARCArchiveCreateButton.Text = "RARCArchiveCreate";
            this.RARCArchiveCreateButton.UseVisualStyleBackColor = true;
            this.RARCArchiveCreateButton.Click += new System.EventHandler(this.RARCArchiveCreateButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(724, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "BCSV Debug";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IODebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 526);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RARCArchiveCreateButton);
            this.Controls.Add(this.RARCGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Yaz0GroupBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.RARCArchiveGroupBox);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IODebugForm";
            this.Text = "IODebugForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Yaz0GroupBox.ResumeLayout(false);
            this.Yaz0GroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.RARCGroupBox.ResumeLayout(false);
            this.RARCArchiveGroupBox.ResumeLayout(false);
            this.RARCArchiveGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Yaz0Dec;
        private MenuStrip menuStrip1;
        private GroupBox Yaz0GroupBox;
        private Label Yaz0FilePathLabel;
        private ComboBox RARCDecComboBox;
        private Button Yaz0EncButton;
        private ToolStripMenuItem ファイルToolStripMenuItem;
        private Button Yaz0DecRARCExtDirectoryButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusTextToolStripStatusLabel;
        private ToolStripStatusLabel RARCStatusToolStripStatusLabel;
        private ComboBox RARCInFilesComboBox;
        private TextBox RARCInFileBinaryTextBox;
        private Label label1;
        private GroupBox RARCGroupBox;
        private GroupBox RARCArchiveGroupBox;
        private Button RARCExtDictinaryButton;
        private Button Yaz0DecRARCExtDictionaryButton;
        private Button RARCExtDirectoryButton;
        private ComboBox ProjectDirectoryComboBox;
        private Button RARCArchiveCreateButton;
        private Button button1;
    }
}