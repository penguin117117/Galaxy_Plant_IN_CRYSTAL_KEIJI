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
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCDirectoryEdit;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI
{
    public partial class IODebugForm : Form
    {
        private string? _yaz0DecFullPath, _yaz0EncFullPath;
        private string[] _objectDataFilesNameArray = Array.Empty<string>();
        private RARCArchive? rarcArchive = null;

        public IODebugForm()
        {
            InitializeComponent();

            FormUtil.IconSet(this, "設定の歯車組み合わせアイコンその2");

            Yaz0GroupBox.AllowDrop = true;

            var objectDataDirPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, @"ObjectData\");
            _objectDataFilesNameArray = Directory.GetFiles(objectDataDirPath);
            foreach (string fileName in _objectDataFilesNameArray)
            {
                Yaz0DecComboBox.Items.Add(@"ObjectData\" + Path.GetFileName(fileName));
            }

            //Yaz0DecComboBox.Items.Add(@"StageData\MagicGalaxy\MagicGalaxyLight.arc");
            Yaz0DecComboBox.Items.Add(@"StageData\IslandFleetGalaxy\IslandFleetGalaxyScenario.arc");
            Yaz0DecComboBox.Items.Add(@"StageData\IslandFleetGalaxy\IslandFleetGalaxyMap.arc");
            Yaz0DecComboBox.SelectedIndex = 0;
            comboBox1.Enabled = false;
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
            _yaz0DecFullPath = Yaz0FilePathLabel.Text;
            if (File.Exists(_yaz0DecFullPath) == false)
            {
                return;
            }
            Yaz0Decord yaz0Decord = new(_yaz0DecFullPath);
            yaz0Decord.Save(_yaz0DecFullPath, "yaz0dec");
        }

        private void Yaz0GroupBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data is null)
            {
                throw new NullReferenceException(nameof(e) + "がNullでした。");
            }
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int count = 0;
            foreach (string fileName in fileNames)
            {
                if (Path.GetExtension(fileName) == string.Empty) continue;

                Debug.WriteLine($"{count}::{fileName}");
                count++;

                Yaz0FilePathLabel.Text = fileName;

            }
        }

        private void Yaz0GroupBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data == null) 
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else 
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox1.Text = string.Empty;
            byte count = 0;
            Debug.WriteLine(comboBox1.SelectedItem);
            StringBuilder sb = new StringBuilder();
            foreach (byte byteData in rarcArchive.FilePathBinaryDataPairs[comboBox1.SelectedItem.ToString()])
            {
                if (count == 15)
                {
                    sb.AppendLine(byteData.ToString("X2"));
                    count = 0;
                    continue;
                }
                sb.Append(byteData.ToString("X2") + " ");
                count++;
            }

            textBox1.Text = sb.ToString();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void RARCExtDictinaryButton_Click(object sender, EventArgs e)
        {
            RARCStatusToolStripStatusLabel.Text = Path.GetFileName(_yaz0DecFullPath) + "を展開中・・・";
            RARCStatusToolStripStatusLabel.ForeColor = Color.Black;

            _yaz0DecFullPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, Yaz0DecComboBox.Text);
            if (File.Exists(_yaz0DecFullPath) == false)
            {
                return;
            }
            //Yaz0Decord yaz0Decord = new(_yaz0DecFullPath);
            rarcArchive = RARCFile.OpenRead(_yaz0DecFullPath);

            if (rarcArchive == null) 
            {
                comboBox1.Enabled = false;
                textBox1.Enabled = false;
                comboBox1.Items.Clear();
                textBox1.Text = string.Empty;
                comboBox1.Text = string.Empty;

                RARCStatusToolStripStatusLabel.Text = Path.GetFileName(_yaz0DecFullPath) + "の展開に失敗しました。";
                RARCStatusToolStripStatusLabel.ForeColor = Color.Red;
                return;
            } 

            RARCArchiveDataEdit rarcArchiveDataEdit = new();
            rarcArchiveDataEdit.ExtractToDictionary(rarcArchive, _yaz0DecFullPath);
            RARCStatusToolStripStatusLabel.Text = Path.GetFileName(_yaz0DecFullPath) + "の展開に成功しました。";
            RARCStatusToolStripStatusLabel.ForeColor = Color.Green;


            comboBox1.Items.Clear();
            foreach (KeyValuePair<string, byte[]> keyValuePair in rarcArchive.FilePathBinaryDataPairs)
            {
                comboBox1.Items.Add(keyValuePair.Key);
            }
            if (rarcArchive.FilePathBinaryDataPairs.Count < 1)
            {
                return;
            }

            comboBox1.Enabled = true;
            textBox1.Enabled = true;
            comboBox1.SelectedItem = rarcArchive.FilePathBinaryDataPairs.Keys.First();
        }

        private void Yaz0DecRARCExtDictionaryButton_Click(object sender, EventArgs e)
        {
            RARCStatusToolStripStatusLabel.Text = Path.GetFileName(_yaz0DecFullPath) + "を展開中・・・";
            RARCStatusToolStripStatusLabel.ForeColor = Color.Black;

            _yaz0DecFullPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, Yaz0DecComboBox.Text);
            if (File.Exists(_yaz0DecFullPath) == false)
            {
                return;
            }
            Yaz0Decord yaz0Decord = new(_yaz0DecFullPath);
            rarcArchive = RARCFile.OpenRead(yaz0Decord.BinaryData);
            RARCArchiveDataEdit rarcArchiveDataEdit = new();
            rarcArchiveDataEdit.ExtractToDictionary(rarcArchive, _yaz0DecFullPath);
            RARCStatusToolStripStatusLabel.Text = Path.GetFileName(_yaz0DecFullPath) + "の展開に成功しました。";
            RARCStatusToolStripStatusLabel.ForeColor = Color.Green;


            comboBox1.Items.Clear();
            foreach (KeyValuePair<string, byte[]> keyValuePair in rarcArchive.FilePathBinaryDataPairs)
            {
                comboBox1.Items.Add(keyValuePair.Key);
            }
            if (rarcArchive.FilePathBinaryDataPairs.Count < 1)
            {
                return;
            }

            comboBox1.Enabled = true;
            textBox1.Enabled = true;
            comboBox1.SelectedItem = rarcArchive.FilePathBinaryDataPairs.Keys.First();
        }

        private void RARCExtDirectoryButton_Click(object sender, EventArgs e)
        {
            RARCStatusToolStripStatusLabel.Text = Path.GetFileName(_yaz0DecFullPath) + "を展開中・・・";
            RARCStatusToolStripStatusLabel.ForeColor = Color.Black;

            _yaz0DecFullPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, Yaz0DecComboBox.Text);
            if (File.Exists(_yaz0DecFullPath) == false)
            {
                return;
            }
            //Yaz0Decord yaz0Decord = new(_yaz0DecFullPath);
            rarcArchive = RARCFile.OpenRead(_yaz0DecFullPath);
            RARCArchiveDataEdit rarcArchiveDataEdit = new();
            rarcArchiveDataEdit.ExtractToDirectory(rarcArchive, _yaz0DecFullPath);
            RARCStatusToolStripStatusLabel.Text = Path.GetFileName(_yaz0DecFullPath) + "の展開に成功しました。";
            RARCStatusToolStripStatusLabel.ForeColor = Color.Green;


            comboBox1.Items.Clear();
            foreach (KeyValuePair<string, byte[]> keyValuePair in rarcArchive.FilePathBinaryDataPairs)
            {
                comboBox1.Items.Add(keyValuePair.Key);
            }
            if (rarcArchive.FilePathBinaryDataPairs.Count < 1)
            {
                return;
            }

            comboBox1.Enabled = true;
            comboBox1.SelectedItem = rarcArchive.FilePathBinaryDataPairs.Keys.First();
        }

        private void Yaz0DecRARCExtDirectoryButton_Click(object sender, EventArgs e)
        {
            RARCStatusToolStripStatusLabel.Text = Path.GetFileName(_yaz0DecFullPath) + "を展開中・・・";
            RARCStatusToolStripStatusLabel.ForeColor = Color.Black;

            _yaz0DecFullPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, Yaz0DecComboBox.Text);
            if (File.Exists(_yaz0DecFullPath) == false)
            {
                return;
            }
            Yaz0Decord yaz0Decord = new(_yaz0DecFullPath);
            rarcArchive = RARCFile.OpenRead(yaz0Decord.BinaryData);
            RARCArchiveDataEdit rarcArchiveDataEdit = new();
            rarcArchiveDataEdit.ExtractToDirectory(rarcArchive, _yaz0DecFullPath);
            RARCStatusToolStripStatusLabel.Text = Path.GetFileName(_yaz0DecFullPath) + "の展開に成功しました。";
            RARCStatusToolStripStatusLabel.ForeColor = Color.Green;


            comboBox1.Items.Clear();
            foreach (KeyValuePair<string, byte[]> keyValuePair in rarcArchive.FilePathBinaryDataPairs)
            {
                comboBox1.Items.Add(keyValuePair.Key);
            }
            if (rarcArchive.FilePathBinaryDataPairs.Count < 1)
            {
                return;
            }

            comboBox1.Enabled = true;
            comboBox1.SelectedItem = rarcArchive.FilePathBinaryDataPairs.Keys.First();


        }

        private void Yaz0EncButton_Click(object sender, EventArgs e)
        {
            _yaz0EncFullPath = Yaz0FilePathLabel.Text;
            if (File.Exists(_yaz0EncFullPath) == false)
            {
                return;
            }
            Yaz0Encord yaz0Encord = new(File.ReadAllBytes(_yaz0EncFullPath));
            yaz0Encord.FileWrite(_yaz0EncFullPath, "yaz0");
        }

    }
}
