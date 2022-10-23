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
            this.Yaz0DecComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusTextToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.RARCStatusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RARCGroupBox = new System.Windows.Forms.GroupBox();
            this.RARCExtDirectoryButton = new System.Windows.Forms.Button();
            this.Yaz0DecRARCExtDictionaryButton = new System.Windows.Forms.Button();
            this.RARCExtDictinaryButton = new System.Windows.Forms.Button();
            this.RARCArchiveGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.menuStrip1.Size = new System.Drawing.Size(444, 24);
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
            this.Yaz0DecRARCExtDirectoryButton.Location = new System.Drawing.Point(6, 46);
            this.Yaz0DecRARCExtDirectoryButton.Name = "Yaz0DecRARCExtDirectoryButton";
            this.Yaz0DecRARCExtDirectoryButton.Size = new System.Drawing.Size(148, 23);
            this.Yaz0DecRARCExtDirectoryButton.TabIndex = 6;
            this.Yaz0DecRARCExtDirectoryButton.Text = "Yaz0DecRARCExtDirectory";
            this.Yaz0DecRARCExtDirectoryButton.UseVisualStyleBackColor = true;
            this.Yaz0DecRARCExtDirectoryButton.Click += new System.EventHandler(this.Yaz0DecRARCExtDirectoryButton_Click);
            // 
            // Yaz0DecComboBox
            // 
            this.Yaz0DecComboBox.FormattingEnabled = true;
            this.Yaz0DecComboBox.Location = new System.Drawing.Point(6, 17);
            this.Yaz0DecComboBox.Name = "Yaz0DecComboBox";
            this.Yaz0DecComboBox.Size = new System.Drawing.Size(406, 23);
            this.Yaz0DecComboBox.TabIndex = 4;
            this.Yaz0DecComboBox.SelectedIndexChanged += new System.EventHandler(this.Yaz0DecComboBox_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusTextToolStripStatusLabel,
            this.RARCStatusToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(444, 22);
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(394, 23);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 51);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(394, 142);
            this.textBox1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(287, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "↓アーカイブ内のファイル";
            // 
            // RARCGroupBox
            // 
            this.RARCGroupBox.Controls.Add(this.label2);
            this.RARCGroupBox.Controls.Add(this.RARCExtDirectoryButton);
            this.RARCGroupBox.Controls.Add(this.Yaz0DecRARCExtDictionaryButton);
            this.RARCGroupBox.Controls.Add(this.RARCExtDictinaryButton);
            this.RARCGroupBox.Controls.Add(this.RARCArchiveGroupBox);
            this.RARCGroupBox.Controls.Add(this.Yaz0DecComboBox);
            this.RARCGroupBox.Controls.Add(this.label1);
            this.RARCGroupBox.Controls.Add(this.Yaz0DecRARCExtDirectoryButton);
            this.RARCGroupBox.Location = new System.Drawing.Point(12, 104);
            this.RARCGroupBox.Name = "RARCGroupBox";
            this.RARCGroupBox.Size = new System.Drawing.Size(418, 397);
            this.RARCGroupBox.TabIndex = 12;
            this.RARCGroupBox.TabStop = false;
            this.RARCGroupBox.Text = "RARCFile";
            // 
            // RARCExtDirectoryButton
            // 
            this.RARCExtDirectoryButton.Location = new System.Drawing.Point(6, 75);
            this.RARCExtDirectoryButton.Name = "RARCExtDirectoryButton";
            this.RARCExtDirectoryButton.Size = new System.Drawing.Size(148, 23);
            this.RARCExtDirectoryButton.TabIndex = 15;
            this.RARCExtDirectoryButton.Text = "RARCExtDirectory";
            this.RARCExtDirectoryButton.UseVisualStyleBackColor = true;
            this.RARCExtDirectoryButton.Click += new System.EventHandler(this.RARCExtDirectoryButton_Click);
            // 
            // Yaz0DecRARCExtDictionaryButton
            // 
            this.Yaz0DecRARCExtDictionaryButton.Location = new System.Drawing.Point(258, 46);
            this.Yaz0DecRARCExtDictionaryButton.Name = "Yaz0DecRARCExtDictionaryButton";
            this.Yaz0DecRARCExtDictionaryButton.Size = new System.Drawing.Size(148, 23);
            this.Yaz0DecRARCExtDictionaryButton.TabIndex = 14;
            this.Yaz0DecRARCExtDictionaryButton.Text = "Yaz0DecRARCExtDictionary";
            this.Yaz0DecRARCExtDictionaryButton.UseVisualStyleBackColor = true;
            this.Yaz0DecRARCExtDictionaryButton.Click += new System.EventHandler(this.Yaz0DecRARCExtDictionaryButton_Click);
            // 
            // RARCExtDictinaryButton
            // 
            this.RARCExtDictinaryButton.Location = new System.Drawing.Point(258, 75);
            this.RARCExtDictinaryButton.Name = "RARCExtDictinaryButton";
            this.RARCExtDictinaryButton.Size = new System.Drawing.Size(148, 23);
            this.RARCExtDictinaryButton.TabIndex = 13;
            this.RARCExtDictinaryButton.Text = "RARCExtDictinary";
            this.RARCExtDictinaryButton.UseVisualStyleBackColor = true;
            this.RARCExtDictinaryButton.Click += new System.EventHandler(this.RARCExtDictinaryButton_Click);
            // 
            // RARCArchiveGroupBox
            // 
            this.RARCArchiveGroupBox.Controls.Add(this.comboBox1);
            this.RARCArchiveGroupBox.Controls.Add(this.textBox1);
            this.RARCArchiveGroupBox.Location = new System.Drawing.Point(6, 186);
            this.RARCArchiveGroupBox.Name = "RARCArchiveGroupBox";
            this.RARCArchiveGroupBox.Size = new System.Drawing.Size(406, 205);
            this.RARCArchiveGroupBox.TabIndex = 12;
            this.RARCArchiveGroupBox.TabStop = false;
            this.RARCArchiveGroupBox.Text = "RARCArchive";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 45);
            this.label2.TabIndex = 16;
            this.label2.Text = "XXXXDirectoryはファイルの生成と内部データの取り込みを行います。\r\nXXXXDictionaryは内部データの取り込みのみ行います。\r\n生成機能と読み" +
    "込みの機能で分かれています。";
            // 
            // IODebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 526);
            this.Controls.Add(this.RARCGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Yaz0GroupBox);
            this.Controls.Add(this.menuStrip1);
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
            this.RARCGroupBox.PerformLayout();
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
        private ComboBox Yaz0DecComboBox;
        private Button Yaz0EncButton;
        private ToolStripMenuItem ファイルToolStripMenuItem;
        private Button Yaz0DecRARCExtDirectoryButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusTextToolStripStatusLabel;
        private ToolStripStatusLabel RARCStatusToolStripStatusLabel;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label1;
        private GroupBox RARCGroupBox;
        private GroupBox RARCArchiveGroupBox;
        private Button RARCExtDictinaryButton;
        private Button Yaz0DecRARCExtDictionaryButton;
        private Button RARCExtDirectoryButton;
        private Label label2;
    }
}