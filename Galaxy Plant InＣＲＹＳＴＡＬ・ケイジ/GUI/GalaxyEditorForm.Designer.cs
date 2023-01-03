namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI
{
    partial class GalaxyEditorForm
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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.GalaxyNameToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ScenarioComboBox = new System.Windows.Forms.ComboBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ObjectMainPanel = new System.Windows.Forms.Panel();
            this.ScenarioMainPanel = new System.Windows.Forms.Panel();
            this.ScenarioNameDisplayLabel = new System.Windows.Forms.Label();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.ObjectMainPanel.SuspendLayout();
            this.ScenarioMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GalaxyNameToolStripStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 428);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(800, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "StatusStrip";
            // 
            // GalaxyNameToolStripStatusLabel
            // 
            this.GalaxyNameToolStripStatusLabel.Name = "GalaxyNameToolStripStatusLabel";
            this.GalaxyNameToolStripStatusLabel.Size = new System.Drawing.Size(73, 17);
            this.GalaxyNameToolStripStatusLabel.Text = "GalaxyName";
            // 
            // ScenarioComboBox
            // 
            this.ScenarioComboBox.FormattingEnabled = true;
            this.ScenarioComboBox.Location = new System.Drawing.Point(11, 18);
            this.ScenarioComboBox.Name = "ScenarioComboBox";
            this.ScenarioComboBox.Size = new System.Drawing.Size(277, 23);
            this.ScenarioComboBox.TabIndex = 2;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ObjectMainPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 24);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(800, 404);
            this.MainPanel.TabIndex = 3;
            // 
            // ObjectMainPanel
            // 
            this.ObjectMainPanel.Controls.Add(this.ScenarioMainPanel);
            this.ObjectMainPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ObjectMainPanel.Location = new System.Drawing.Point(0, 0);
            this.ObjectMainPanel.Name = "ObjectMainPanel";
            this.ObjectMainPanel.Size = new System.Drawing.Size(301, 404);
            this.ObjectMainPanel.TabIndex = 3;
            // 
            // ScenarioMainPanel
            // 
            this.ScenarioMainPanel.Controls.Add(this.ScenarioNameDisplayLabel);
            this.ScenarioMainPanel.Controls.Add(this.ScenarioComboBox);
            this.ScenarioMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScenarioMainPanel.Location = new System.Drawing.Point(0, 0);
            this.ScenarioMainPanel.Name = "ScenarioMainPanel";
            this.ScenarioMainPanel.Size = new System.Drawing.Size(301, 120);
            this.ScenarioMainPanel.TabIndex = 4;
            // 
            // ScenarioNameDisplayLabel
            // 
            this.ScenarioNameDisplayLabel.AutoSize = true;
            this.ScenarioNameDisplayLabel.Location = new System.Drawing.Point(11, 0);
            this.ScenarioNameDisplayLabel.Name = "ScenarioNameDisplayLabel";
            this.ScenarioNameDisplayLabel.Size = new System.Drawing.Size(83, 15);
            this.ScenarioNameDisplayLabel.TabIndex = 3;
            this.ScenarioNameDisplayLabel.Text = "ScenarioName";
            // 
            // GalaxyEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "GalaxyEditorForm";
            this.Text = "GalaxyEditorForm";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.ObjectMainPanel.ResumeLayout(false);
            this.ScenarioMainPanel.ResumeLayout(false);
            this.ScenarioMainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip MenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private StatusStrip StatusStrip;
        private ComboBox ScenarioComboBox;
        private Panel MainPanel;
        private Panel ObjectMainPanel;
        private Panel ScenarioMainPanel;
        private ToolStripStatusLabel GalaxyNameToolStripStatusLabel;
        private Label ScenarioNameDisplayLabel;
    }
}