using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.Yaz0;
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
    public partial class IODebugForm : Form
    {
        private string _yaz0DecFullPath;
        private string[] _objectDataFilesNameArray;

        public IODebugForm()
        {
            InitializeComponent();

            var objectDataDirPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, @"ObjectData\");
            _objectDataFilesNameArray = Directory.GetFiles(objectDataDirPath);
            foreach (string fileName in _objectDataFilesNameArray) 
            {
                Yaz0TargetFileNameComboBox.Items.Add(@"ObjectData\" + Path.GetFileName(fileName));
            }

            
            Yaz0TargetFileNameComboBox.Items.Add(@"StageData\MagicGalaxy\MagicGalaxyLight.arc");
            Yaz0TargetFileNameComboBox.SelectedIndex = 0;
        }

        private void ButtonDisable() 
        {
            foreach (Control control in this.Controls)
            {
                if (control is ComboBox || control is Button) 
                {
                    control.Enabled = false;
                }
                    
            }
        }

        private void Yaz0Dec_Click(object sender, EventArgs e)
        {
            _yaz0DecFullPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath,Yaz0TargetFileNameComboBox.Text);
            if (File.Exists(_yaz0DecFullPath) == false) 
            {
                return;
            }
            Yaz0FilePathLabel.Text = _yaz0DecFullPath;
            Yaz0Decord yaz0Decord = new(_yaz0DecFullPath);
            yaz0Decord.Save(_yaz0DecFullPath);
        }

        private void Yaz0EncButton_Click(object sender, EventArgs e)
        {

        }
    }
}
