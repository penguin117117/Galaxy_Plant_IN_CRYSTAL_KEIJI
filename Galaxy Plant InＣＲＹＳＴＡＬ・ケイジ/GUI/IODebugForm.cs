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
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSVFileFormat;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI
{
    public partial class IODebugForm : Form
    {
        private string? _yaz0DecFullPath, _yaz0EncFullPath;
        private string[] _objectDataFilesNameArray = Array.Empty<string>();
        private Dictionary<string, string[]> filesInSubfolders = new();
        private RARCArchive? rarcArchive = null;

        public IODebugForm()
        {
            InitializeComponent();

            FormUtil.IconSet(this, "設定の歯車組み合わせアイコンその2");

            Yaz0GroupBox.AllowDrop = true;

            var projectDirectories = Directory.GetDirectories(Properties.Settings.Default.GalaxyProjectPath);

            foreach (string projectSubDirectoryFullPath in projectDirectories) 
            {
                if (Directory.Exists(projectSubDirectoryFullPath)) 
                {
                    var projectSubDirectoryName = Path.GetFileName(projectSubDirectoryFullPath);

                    var files = Directory.GetFiles(projectSubDirectoryFullPath);

                    filesInSubfolders.Add(projectSubDirectoryName, files);
                    ProjectDirectoryComboBox.Items.Add(projectSubDirectoryName);
                }
            }
            if (ProjectDirectoryComboBox.Items.Count < 1) 
            {
                return;
            }
            ProjectDirectoryComboBox.SelectedIndex = 0;

            SetRARCDecComboBoxItems();
            
            RARCInFilesComboBox.Enabled = false;
        }

        private void SetRARCDecComboBoxItems() 
        {
            if (ProjectDirectoryComboBox.SelectedItem == null) 
            {
                return;
            }

            var objectDataDirPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, (string)ProjectDirectoryComboBox.SelectedItem);
            Debug.WriteLine(objectDataDirPath);
            _objectDataFilesNameArray = Directory.GetFiles(objectDataDirPath);
            foreach (string fileName in _objectDataFilesNameArray)
            {
                RARCDecComboBox.Items.Add($"{ProjectDirectoryComboBox.SelectedItem}\\{Path.GetFileName(fileName)}");
            }


            if (RARCDecComboBox.Items.Count > 0)
            {
                RARCDecComboBox.SelectedIndex = 0;
                RARCDecComboBox.Enabled = true;
            }
            else 
            {
                RARCDecComboBox.Enabled = false;
            }
                
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

        private void RARCInFilesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rarcArchive == null) return;
            RARCInFileBinaryTextBox.Text = string.Empty;
            byte count = 0;
            Debug.WriteLine(RARCInFilesComboBox.SelectedItem);



            StringBuilder sb = new();
            foreach (byte byteData in rarcArchive.FilePathBinaryDataPairs[(string)RARCInFilesComboBox.SelectedItem])
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

            RARCInFileBinaryTextBox.Text = sb.ToString();
        }

        private void RARCInFilesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void RARCExtDictinaryButton_Click(object sender, EventArgs e)
        {
            SetRARCStatusToolStripStatusLabelText(Path.GetFileName(_yaz0DecFullPath) + "を展開中・・・", Color.Black);

            _yaz0DecFullPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, RARCDecComboBox.Text);

            if (File.Exists(_yaz0DecFullPath) == false)
            {
                return;
            }

            rarcArchive = RARCFile.OpenRead(_yaz0DecFullPath);

            if (rarcArchive == null) 
            {
                RARCInFilesComboBox.Enabled = false;
                RARCInFileBinaryTextBox.Enabled = false;

                RARCInFilesComboBox.Items.Clear();

                RARCInFileBinaryTextBox.Text = string.Empty;
                RARCInFilesComboBox.Text = string.Empty;

                SetRARCStatusToolStripStatusLabelText(Path.GetFileName(_yaz0DecFullPath) + "の展開に失敗しました。", Color.Red);
                return;
            } 

            RARCArchiveExtract.ToDictionary(rarcArchive, _yaz0DecFullPath);
            SetRARCStatusToolStripStatusLabelText(Path.GetFileName(_yaz0DecFullPath) + "の展開に成功しました。", Color.Green);


            RARCInFilesComboBox.Items.Clear();
            foreach (KeyValuePair<string, byte[]> keyValuePair in rarcArchive.FilePathBinaryDataPairs)
            {
                RARCInFilesComboBox.Items.Add(keyValuePair.Key);
            }
            if (rarcArchive.FilePathBinaryDataPairs.Count < 1)
            {
                return;
            }

            RARCInFilesComboBox.Enabled = true;
            RARCInFileBinaryTextBox.Enabled = true;
            RARCInFilesComboBox.SelectedItem = rarcArchive.FilePathBinaryDataPairs.Keys.First();
        }

        private void Yaz0DecRARCExtDictionaryButton_Click(object sender, EventArgs e)
        {
            SetRARCStatusToolStripStatusLabelText(Path.GetFileName(_yaz0DecFullPath) + "を展開中・・・", Color.Black);

            _yaz0DecFullPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, RARCDecComboBox.Text);
            if (File.Exists(_yaz0DecFullPath) == false)
            {
                return;
            }
            Yaz0Decord? yaz0Decord = new(_yaz0DecFullPath);
            rarcArchive = RARCFile.OpenRead(yaz0Decord.BinaryData);
            RARCArchiveExtract.ToDictionary(rarcArchive, _yaz0DecFullPath);
            SetRARCStatusToolStripStatusLabelText(Path.GetFileName(_yaz0DecFullPath) + "の展開に成功しました。", Color.Green);


            RARCInFilesComboBox.Items.Clear();
            foreach (KeyValuePair<string, byte[]> keyValuePair in rarcArchive.FilePathBinaryDataPairs)
            {
                RARCInFilesComboBox.Items.Add(keyValuePair.Key);
            }
            if (rarcArchive.FilePathBinaryDataPairs.Count < 1)
            {
                return;
            }

            RARCInFilesComboBox.Enabled = true;
            RARCInFileBinaryTextBox.Enabled = true;
            RARCInFilesComboBox.SelectedItem = rarcArchive.FilePathBinaryDataPairs.Keys.First();
        }

        private void RARCExtDirectoryButton_Click(object sender, EventArgs e)
        {
            SetRARCStatusToolStripStatusLabelText(Path.GetFileName(_yaz0DecFullPath) + "を展開中・・・", Color.Black);

            _yaz0DecFullPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, RARCDecComboBox.Text);
            if (File.Exists(_yaz0DecFullPath) == false)
            {
                return;
            }
            //Yaz0Decord yaz0Decord = new(_yaz0DecFullPath);
            rarcArchive = RARCFile.OpenRead(_yaz0DecFullPath);
            if (rarcArchive == null) return;
            RARCArchiveExtract.ToDirectory(rarcArchive, _yaz0DecFullPath);
            SetRARCStatusToolStripStatusLabelText(Path.GetFileName(_yaz0DecFullPath) + "の展開に成功しました。", Color.Green);


            RARCInFilesComboBox.Items.Clear();
            foreach (KeyValuePair<string, byte[]> keyValuePair in rarcArchive.FilePathBinaryDataPairs)
            {
                RARCInFilesComboBox.Items.Add(keyValuePair.Key);
            }
            if (rarcArchive.FilePathBinaryDataPairs.Count < 1)
            {
                return;
            }

            RARCInFilesComboBox.Enabled = true;
            RARCInFilesComboBox.SelectedItem = rarcArchive.FilePathBinaryDataPairs.Keys.First();
        }

        private void Yaz0DecRARCExtDirectoryButton_Click(object sender, EventArgs e)
        {
            SetRARCStatusToolStripStatusLabelText(Path.GetFileName(_yaz0DecFullPath) + "を展開中・・・", Color.Black);

            _yaz0DecFullPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, RARCDecComboBox.Text);
            if (File.Exists(_yaz0DecFullPath) == false)
            {
                return;
            }
            Yaz0Decord yaz0Decord = new(_yaz0DecFullPath);

            //RARCFile.ExtractToDirectory(yaz0Decord.BinaryData, "");

            rarcArchive = RARCFile.OpenRead(yaz0Decord.BinaryData);
            RARCArchiveExtract.ToDirectory(rarcArchive, _yaz0DecFullPath);

            SetRARCStatusToolStripStatusLabelText(Path.GetFileName(_yaz0DecFullPath) + "の展開に成功しました。", Color.Green);
            


            RARCInFilesComboBox.Items.Clear();
            foreach (KeyValuePair<string, byte[]> keyValuePair in rarcArchive.FilePathBinaryDataPairs)
            {
                RARCInFilesComboBox.Items.Add(keyValuePair.Key);
            }
            if (rarcArchive.FilePathBinaryDataPairs.Count < 1)
            {
                return;
            }

            RARCInFilesComboBox.Enabled = true;
            RARCInFilesComboBox.SelectedItem = rarcArchive.FilePathBinaryDataPairs.Keys.First();


        }

        private void ProjectDirectoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RARCDecComboBox.Items.Clear();
            RARCDecComboBox.SelectedText = String.Empty;
            SetRARCDecComboBoxItems();
            
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

        private void RARCArchiveCreateButton_Click(object sender, EventArgs e)
        {
            string sourceDirPath = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, @"ObjectData\RARC_テスト\Abekobe2DMoveLift\");
            RARCArchiveCreate.FromDirectory(sourceDirPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, @"ObjectData\Battan\Battan\ActorInfo\ActionFlagCtrl.bcsv");
            BCSVFile.ReadEntries(path);
        }

        private void SetRARCStatusToolStripStatusLabelText(string message,Color color) 
        {
            RARCStatusToolStripStatusLabel.Text = message;
            RARCStatusToolStripStatusLabel.ForeColor = color;
        }
    }
}
