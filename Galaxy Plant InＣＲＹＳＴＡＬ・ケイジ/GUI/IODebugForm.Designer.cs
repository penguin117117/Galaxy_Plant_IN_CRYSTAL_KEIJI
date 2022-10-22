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
            this.Yaz0EncComboBox = new System.Windows.Forms.ComboBox();
            this.Yaz0DecRARCExtButton = new System.Windows.Forms.Button();
            this.Yaz0DecComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusTextToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.RARCStatusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.Yaz0GroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            this.Yaz0GroupBox.Location = new System.Drawing.Point(12, 38);
            this.Yaz0GroupBox.Name = "Yaz0GroupBox";
            this.Yaz0GroupBox.Size = new System.Drawing.Size(776, 71);
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
            // Yaz0EncComboBox
            // 
            this.Yaz0EncComboBox.FormattingEnabled = true;
            this.Yaz0EncComboBox.Location = new System.Drawing.Point(12, 402);
            this.Yaz0EncComboBox.Name = "Yaz0EncComboBox";
            this.Yaz0EncComboBox.Size = new System.Drawing.Size(302, 23);
            this.Yaz0EncComboBox.TabIndex = 8;
            this.Yaz0EncComboBox.SelectedIndexChanged += new System.EventHandler(this.Yaz0EncComboBox_SelectedIndexChanged);
            // 
            // Yaz0DecRARCExtButton
            // 
            this.Yaz0DecRARCExtButton.Location = new System.Drawing.Point(320, 372);
            this.Yaz0DecRARCExtButton.Name = "Yaz0DecRARCExtButton";
            this.Yaz0DecRARCExtButton.Size = new System.Drawing.Size(148, 23);
            this.Yaz0DecRARCExtButton.TabIndex = 6;
            this.Yaz0DecRARCExtButton.Text = "Yaz0DecRARCExt";
            this.Yaz0DecRARCExtButton.UseVisualStyleBackColor = true;
            this.Yaz0DecRARCExtButton.Click += new System.EventHandler(this.Yaz0DecRARCExtButton_Click);
            // 
            // Yaz0DecComboBox
            // 
            this.Yaz0DecComboBox.FormattingEnabled = true;
            this.Yaz0DecComboBox.Location = new System.Drawing.Point(12, 373);
            this.Yaz0DecComboBox.Name = "Yaz0DecComboBox";
            this.Yaz0DecComboBox.Size = new System.Drawing.Size(302, 23);
            this.Yaz0DecComboBox.TabIndex = 4;
            this.Yaz0DecComboBox.SelectedIndexChanged += new System.EventHandler(this.Yaz0DecComboBox_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusTextToolStripStatusLabel,
            this.RARCStatusToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
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
            // IODebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Yaz0EncComboBox);
            this.Controls.Add(this.Yaz0DecRARCExtButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Yaz0GroupBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Yaz0DecComboBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IODebugForm";
            this.Text = "IODebugForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Yaz0GroupBox.ResumeLayout(false);
            this.Yaz0GroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private Button Yaz0DecRARCExtButton;
        private ComboBox Yaz0EncComboBox;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusTextToolStripStatusLabel;
        private ToolStripStatusLabel RARCStatusToolStripStatusLabel;
    }
}