using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.Yaz0;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI
{
    public partial class IODebugForm : Form
    {
        private string _yaz0DecFullPath, _yaz0EncFullPath;
        private string[] _objectDataFilesNameArray, _objectDataDirectoryNameArray;

        public IODebugForm()
        {
            InitializeComponent();

            var objectDataDirPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, @"ObjectData\");
            _objectDataFilesNameArray = Directory.GetFiles(objectDataDirPath);
            foreach (string fileName in _objectDataFilesNameArray) 
            {

                Yaz0DecComboBox.Items.Add(@"ObjectData\" + Path.GetFileName(fileName));
                Yaz0EncComboBox.Items.Add(@"ObjectData\" + Path.GetFileName(fileName));
            }

            //Yaz0DecComboBox.Items.Add(@"StageData\MagicGalaxy\MagicGalaxyLight.arc");
            Yaz0DecComboBox.Items.Add(@"StageData\IslandFleetGalaxy\IslandFleetGalaxyScenario.arc");
            Yaz0DecComboBox.Items.Add(@"StageData\IslandFleetGalaxy\IslandFleetGalaxyMap.arc");
            Yaz0DecComboBox.SelectedIndex = 0;
            Yaz0DecComboBox.SelectedIndex = 0;
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

        private void Yaz0EncComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Yaz0DecComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Yaz0Dec_Click(object sender, EventArgs e)
        {
            _yaz0DecFullPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath,Yaz0DecComboBox.Text);
            if (File.Exists(_yaz0DecFullPath) == false) 
            {
                return;
            }
            //Yaz0FilePathLabel.Text = _yaz0DecFullPath;
            Yaz0Decord yaz0Decord = new(_yaz0DecFullPath);
            yaz0Decord.Save(_yaz0DecFullPath);
        }

        private void Yaz0DecRARCExtButton_Click(object sender, EventArgs e)
        {
            RARCStatusToolStripStatusLabel.Text = Path.GetFileName(_yaz0DecFullPath) + "を展開中・・・";
            RARCStatusToolStripStatusLabel.ForeColor = Color.Black;

            _yaz0DecFullPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, Yaz0DecComboBox.Text);
            if (File.Exists(_yaz0DecFullPath) == false)
            {
                return;
            }
            Yaz0Decord yaz0Decord = new(_yaz0DecFullPath);
            RARCFile.ExtractToDirectory(yaz0Decord.BinaryData, _yaz0DecFullPath);
            //byte[]? nullTest = null;
            //RARCFile.ExtractToDirectory(nullTest, _yaz0DecFullPath);
            RARCStatusToolStripStatusLabel.Text = Path.GetFileName(_yaz0DecFullPath) + "の展開に成功しました。";
            RARCStatusToolStripStatusLabel.ForeColor = Color.Green;
        }

        private void Yaz0EncButton_Click(object sender, EventArgs e)
        {
            _yaz0EncFullPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, Yaz0EncComboBox.Text);
            if (File.Exists(_yaz0EncFullPath) == false)
            {
                return;
            }
            Yaz0Encord yaz0Encord = new(File.ReadAllBytes(_yaz0EncFullPath));
            yaz0Encord.FileWrite(_yaz0EncFullPath,"yaz0");
            MessageBox.Show("OK");
        }

    }
}
