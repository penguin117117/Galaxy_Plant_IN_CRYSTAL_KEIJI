using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI
{
    public partial class SystemSettingForm : Form
    {
        private readonly string[] languages = 
            new string[] { "日本語" , "English" };

        public SystemSettingForm()
        {
            InitializeComponent();
        }

        private void SystemSettingForm_Load(object sender, EventArgs e)
        {
            LanguageComboBox.Items.AddRange(languages);
            LanguageComboBox.SelectedItem = LanguageComboBox.Items.Contains(Properties.Settings.Default.Language)? Properties.Settings.Default.Language :languages[0];

            AdvancedViewCheckBox.Checked = Properties.Settings.Default.AdvancedView;
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox? langComboBox = sender as ComboBox;

            langComboBox = 
                langComboBox ?? throw new NullReferenceException();

            Properties.Settings.Default.Language = (string)langComboBox.SelectedItem;
            Properties.Settings.Default.Save();
        }

        private void AdvancedViewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox? advancedViewCheckBox = sender as CheckBox;
            advancedViewCheckBox = 
                advancedViewCheckBox ?? throw new NullReferenceException();

            Properties.Settings.Default.AdvancedView = advancedViewCheckBox.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
