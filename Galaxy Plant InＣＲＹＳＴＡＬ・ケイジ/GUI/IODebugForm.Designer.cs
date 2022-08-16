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
            this.Yaz0TargetFileNameComboBox = new System.Windows.Forms.ComboBox();
            this.Yaz0FilePathLabel = new System.Windows.Forms.Label();
            this.Yaz0DecRARCExtButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.Yaz0GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Yaz0Dec
            // 
            this.Yaz0Dec.Location = new System.Drawing.Point(6, 66);
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
            this.Yaz0GroupBox.Controls.Add(this.Yaz0DecRARCExtButton);
            this.Yaz0GroupBox.Controls.Add(this.Yaz0EncButton);
            this.Yaz0GroupBox.Controls.Add(this.Yaz0TargetFileNameComboBox);
            this.Yaz0GroupBox.Controls.Add(this.Yaz0FilePathLabel);
            this.Yaz0GroupBox.Controls.Add(this.Yaz0Dec);
            this.Yaz0GroupBox.Location = new System.Drawing.Point(12, 38);
            this.Yaz0GroupBox.Name = "Yaz0GroupBox";
            this.Yaz0GroupBox.Size = new System.Drawing.Size(776, 166);
            this.Yaz0GroupBox.TabIndex = 2;
            this.Yaz0GroupBox.TabStop = false;
            this.Yaz0GroupBox.Text = "Yaz0";
            // 
            // Yaz0EncButton
            // 
            this.Yaz0EncButton.Location = new System.Drawing.Point(160, 66);
            this.Yaz0EncButton.Name = "Yaz0EncButton";
            this.Yaz0EncButton.Size = new System.Drawing.Size(148, 23);
            this.Yaz0EncButton.TabIndex = 5;
            this.Yaz0EncButton.Text = "Yaz0Enc";
            this.Yaz0EncButton.UseVisualStyleBackColor = true;
            this.Yaz0EncButton.Click += new System.EventHandler(this.Yaz0EncButton_Click);
            // 
            // Yaz0TargetFileNameComboBox
            // 
            this.Yaz0TargetFileNameComboBox.FormattingEnabled = true;
            this.Yaz0TargetFileNameComboBox.Location = new System.Drawing.Point(6, 37);
            this.Yaz0TargetFileNameComboBox.Name = "Yaz0TargetFileNameComboBox";
            this.Yaz0TargetFileNameComboBox.Size = new System.Drawing.Size(302, 23);
            this.Yaz0TargetFileNameComboBox.TabIndex = 4;
            // 
            // Yaz0FilePathLabel
            // 
            this.Yaz0FilePathLabel.AutoSize = true;
            this.Yaz0FilePathLabel.Location = new System.Drawing.Point(6, 19);
            this.Yaz0FilePathLabel.Name = "Yaz0FilePathLabel";
            this.Yaz0FilePathLabel.Size = new System.Drawing.Size(69, 15);
            this.Yaz0FilePathLabel.TabIndex = 3;
            this.Yaz0FilePathLabel.Text = "DecFilePath";
            // 
            // Yaz0DecRARCExtButton
            // 
            this.Yaz0DecRARCExtButton.Location = new System.Drawing.Point(6, 137);
            this.Yaz0DecRARCExtButton.Name = "Yaz0DecRARCExtButton";
            this.Yaz0DecRARCExtButton.Size = new System.Drawing.Size(148, 23);
            this.Yaz0DecRARCExtButton.TabIndex = 6;
            this.Yaz0DecRARCExtButton.Text = "Yaz0DecRARCExt";
            this.Yaz0DecRARCExtButton.UseVisualStyleBackColor = true;
            this.Yaz0DecRARCExtButton.Click += new System.EventHandler(this.Yaz0DecRARCExtButton_Click);
            // 
            // IODebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Yaz0GroupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IODebugForm";
            this.Text = "IODebugForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Yaz0GroupBox.ResumeLayout(false);
            this.Yaz0GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Yaz0Dec;
        private MenuStrip menuStrip1;
        private GroupBox Yaz0GroupBox;
        private Label Yaz0FilePathLabel;
        private ComboBox Yaz0TargetFileNameComboBox;
        private Button Yaz0EncButton;
        private ToolStripMenuItem ファイルToolStripMenuItem;
        private Button Yaz0DecRARCExtButton;
    }
}