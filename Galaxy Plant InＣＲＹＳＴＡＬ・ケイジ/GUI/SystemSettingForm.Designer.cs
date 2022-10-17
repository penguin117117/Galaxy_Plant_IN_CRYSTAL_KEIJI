namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI
{
    partial class SystemSettingForm
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GeneralSettingsTabPage = new System.Windows.Forms.TabPage();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.AdvancedSettingsTabPage = new System.Windows.Forms.TabPage();
            this.AdvancedViewCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MainPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.GeneralSettingsTabPage.SuspendLayout();
            this.AdvancedSettingsTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.tabControl1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(434, 199);
            this.MainPanel.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.GeneralSettingsTabPage);
            this.tabControl1.Controls.Add(this.AdvancedSettingsTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(434, 199);
            this.tabControl1.TabIndex = 1;
            // 
            // GeneralSettingsTabPage
            // 
            this.GeneralSettingsTabPage.Controls.Add(this.LanguageComboBox);
            this.GeneralSettingsTabPage.Controls.Add(this.LanguageLabel);
            this.GeneralSettingsTabPage.Location = new System.Drawing.Point(4, 24);
            this.GeneralSettingsTabPage.Name = "GeneralSettingsTabPage";
            this.GeneralSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralSettingsTabPage.Size = new System.Drawing.Size(426, 171);
            this.GeneralSettingsTabPage.TabIndex = 0;
            this.GeneralSettingsTabPage.Text = "一般設定";
            this.GeneralSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Location = new System.Drawing.Point(6, 24);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(121, 23);
            this.LanguageComboBox.TabIndex = 1;
            this.LanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_SelectedIndexChanged);
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.AutoSize = true;
            this.LanguageLabel.Location = new System.Drawing.Point(6, 6);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(59, 15);
            this.LanguageLabel.TabIndex = 2;
            this.LanguageLabel.Text = "Language";
            // 
            // AdvancedSettingsTabPage
            // 
            this.AdvancedSettingsTabPage.Controls.Add(this.groupBox1);
            this.AdvancedSettingsTabPage.Location = new System.Drawing.Point(4, 24);
            this.AdvancedSettingsTabPage.Name = "AdvancedSettingsTabPage";
            this.AdvancedSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AdvancedSettingsTabPage.Size = new System.Drawing.Size(426, 171);
            this.AdvancedSettingsTabPage.TabIndex = 1;
            this.AdvancedSettingsTabPage.Text = "高度な設定";
            this.AdvancedSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // AdvancedViewCheckBox
            // 
            this.AdvancedViewCheckBox.AutoSize = true;
            this.AdvancedViewCheckBox.Location = new System.Drawing.Point(6, 22);
            this.AdvancedViewCheckBox.Name = "AdvancedViewCheckBox";
            this.AdvancedViewCheckBox.Size = new System.Drawing.Size(201, 19);
            this.AdvancedViewCheckBox.TabIndex = 0;
            this.AdvancedViewCheckBox.Text = "上級者向けの設定項目を表示する。";
            this.AdvancedViewCheckBox.UseVisualStyleBackColor = true;
            this.AdvancedViewCheckBox.CheckedChanged += new System.EventHandler(this.AdvancedViewCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AdvancedViewCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本的にOFFにすることをお勧めします。";
            // 
            // SystemSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 199);
            this.Controls.Add(this.MainPanel);
            this.Name = "SystemSettingForm";
            this.Text = "SystemSettingForm";
            this.Load += new System.EventHandler(this.SystemSettingForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.GeneralSettingsTabPage.ResumeLayout(false);
            this.GeneralSettingsTabPage.PerformLayout();
            this.AdvancedSettingsTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel MainPanel;
        private TabControl tabControl1;
        private TabPage GeneralSettingsTabPage;
        private ComboBox LanguageComboBox;
        private Label LanguageLabel;
        private TabPage AdvancedSettingsTabPage;
        private GroupBox groupBox1;
        private CheckBox AdvancedViewCheckBox;
    }
}