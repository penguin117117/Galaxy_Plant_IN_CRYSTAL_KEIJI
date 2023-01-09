namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI
{
    partial class BCSVEditorForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.targetDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RootDirectoryComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.targetSubDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubDirectoryComboBoxNo1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SubDirectoryComboBoxNo2 = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DebugButton = new System.Windows.Forms.Button();
            this.HashTableButton = new System.Windows.Forms.Button();
            this.BCSVSeetPanel = new System.Windows.Forms.Panel();
            this.BCSVSheetTabControl = new System.Windows.Forms.TabControl();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.filePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.BCSVSeetPanel.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.targetDirectoryToolStripMenuItem,
            this.RootDirectoryComboBox,
            this.targetSubDirectoryToolStripMenuItem,
            this.SubDirectoryComboBoxNo1,
            this.toolStripMenuItem1,
            this.SubDirectoryComboBoxNo2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // targetDirectoryToolStripMenuItem
            // 
            this.targetDirectoryToolStripMenuItem.Name = "targetDirectoryToolStripMenuItem";
            this.targetDirectoryToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.targetDirectoryToolStripMenuItem.Text = "ファイル : ";
            // 
            // RootDirectoryComboBox
            // 
            this.RootDirectoryComboBox.Name = "RootDirectoryComboBox";
            this.RootDirectoryComboBox.Size = new System.Drawing.Size(121, 23);
            this.RootDirectoryComboBox.SelectedIndexChanged += new System.EventHandler(this.RootDirectoryComboBox_SelectedIndexChanged);
            this.RootDirectoryComboBox.TextUpdate += new System.EventHandler(this.RootDirectoryComboBox_TextUpdate);
            this.RootDirectoryComboBox.Click += new System.EventHandler(this.RootDirectoryComboBox_Click);
            this.RootDirectoryComboBox.TextChanged += new System.EventHandler(this.RootDirectoryComboBox_TextChanged);
            // 
            // targetSubDirectoryToolStripMenuItem
            // 
            this.targetSubDirectoryToolStripMenuItem.Name = "targetSubDirectoryToolStripMenuItem";
            this.targetSubDirectoryToolStripMenuItem.Size = new System.Drawing.Size(25, 23);
            this.targetSubDirectoryToolStripMenuItem.Text = "\\";
            // 
            // SubDirectoryComboBoxNo1
            // 
            this.SubDirectoryComboBoxNo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubDirectoryComboBoxNo1.Name = "SubDirectoryComboBoxNo1";
            this.SubDirectoryComboBoxNo1.Size = new System.Drawing.Size(121, 23);
            this.SubDirectoryComboBoxNo1.SelectedIndexChanged += new System.EventHandler(this.SubDirectoryComboBox_SelectedIndexChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(25, 23);
            this.toolStripMenuItem1.Text = "\\";
            // 
            // SubDirectoryComboBoxNo2
            // 
            this.SubDirectoryComboBoxNo2.Name = "SubDirectoryComboBoxNo2";
            this.SubDirectoryComboBoxNo2.Size = new System.Drawing.Size(121, 23);
            this.SubDirectoryComboBoxNo2.SelectedIndexChanged += new System.EventHandler(this.SubDirectoryComboBoxNo2_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DebugButton);
            this.panel1.Controls.Add(this.HashTableButton);
            this.panel1.Controls.Add(this.BCSVSeetPanel);
            this.panel1.Controls.Add(this.menuStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 401);
            this.panel1.TabIndex = 2;
            // 
            // DebugButton
            // 
            this.DebugButton.Location = new System.Drawing.Point(671, 48);
            this.DebugButton.Name = "DebugButton";
            this.DebugButton.Size = new System.Drawing.Size(117, 23);
            this.DebugButton.TabIndex = 1;
            this.DebugButton.Text = "BCSVを開く";
            this.DebugButton.UseVisualStyleBackColor = true;
            this.DebugButton.Click += new System.EventHandler(this.DebugButton_Click);
            // 
            // HashTableButton
            // 
            this.HashTableButton.Location = new System.Drawing.Point(671, 94);
            this.HashTableButton.Name = "HashTableButton";
            this.HashTableButton.Size = new System.Drawing.Size(117, 23);
            this.HashTableButton.TabIndex = 2;
            this.HashTableButton.Text = "ハッシュダウンロード";
            this.HashTableButton.UseVisualStyleBackColor = true;
            this.HashTableButton.Click += new System.EventHandler(this.HashTableButton_Click);
            // 
            // BCSVSeetPanel
            // 
            this.BCSVSeetPanel.Controls.Add(this.BCSVSheetTabControl);
            this.BCSVSeetPanel.Controls.Add(this.menuStrip3);
            this.BCSVSeetPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.BCSVSeetPanel.Location = new System.Drawing.Point(0, 24);
            this.BCSVSeetPanel.Name = "BCSVSeetPanel";
            this.BCSVSeetPanel.Size = new System.Drawing.Size(665, 377);
            this.BCSVSeetPanel.TabIndex = 2;
            // 
            // BCSVSheetTabControl
            // 
            this.BCSVSheetTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.BCSVSheetTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BCSVSheetTabControl.Location = new System.Drawing.Point(0, 24);
            this.BCSVSheetTabControl.Name = "BCSVSheetTabControl";
            this.BCSVSheetTabControl.SelectedIndex = 0;
            this.BCSVSheetTabControl.Size = new System.Drawing.Size(665, 353);
            this.BCSVSheetTabControl.TabIndex = 2;
            // 
            // menuStrip3
            // 
            this.menuStrip3.Location = new System.Drawing.Point(0, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(665, 24);
            this.menuStrip3.TabIndex = 1;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filePathToolStripMenuItem,
            this.noneToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // filePathToolStripMenuItem
            // 
            this.filePathToolStripMenuItem.Name = "filePathToolStripMenuItem";
            this.filePathToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.filePathToolStripMenuItem.Text = "FilePath : ";
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.noneToolStripMenuItem.Text = "None";
            // 
            // BCSVEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BCSVEditorForm";
            this.Text = "BCSVEditorForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.BCSVSeetPanel.ResumeLayout(false);
            this.BCSVSeetPanel.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private Panel panel1;
        private MenuStrip menuStrip2;
        private Button DebugButton;
        private Button HashTableButton;
        private ToolStripComboBox RootDirectoryComboBox;
        private ToolStripMenuItem targetDirectoryToolStripMenuItem;
        private ToolStripMenuItem targetSubDirectoryToolStripMenuItem;
        private ToolStripComboBox SubDirectoryComboBoxNo1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripComboBox SubDirectoryComboBoxNo2;
        private ToolStripMenuItem filePathToolStripMenuItem;
        private ToolStripMenuItem noneToolStripMenuItem;
        private Panel BCSVSeetPanel;
        private MenuStrip menuStrip3;
        private TabControl BCSVSheetTabControl;
    }
}