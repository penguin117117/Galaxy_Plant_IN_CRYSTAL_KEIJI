using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI.ControlsSetting.ProjectControls;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI
{
    public partial class BCSVEditorForm : Form
    {
        private Dictionary<string, string[]> projectRootDirectories;
        private Dictionary<string, string[]> projectSubDirectories;

        public BCSVEditorForm()
        {
            InitializeComponent();
            projectRootDirectories = new();
            projectSubDirectories = new();

            //RootDirectorySet
            BCSVComboBoxSetting RootDirComboBoxSetting = new();

            RootDirComboBoxSetting.SetComboBoxItems(
                RootDirectoryComboBox.ComboBox, 
                Directory.GetDirectories(Properties.Settings.Default.GalaxyProjectPath)
                );

            projectRootDirectories = RootDirComboBoxSetting.NameAndPathDictionary;

            RootDirectoryComboBox.SelectedIndex = 0;
            ComboBoxSizeTextFit(RootDirectoryComboBox.ComboBox);
        }

        /// <summary>
        /// コンボボックスのサイズをテキストの長さによって調整します。
        /// </summary>
        /// <param name="cb">調整したい<see cref="ComboBox"/></param>
        private void ComboBoxSizeTextFit(ComboBox cb) 
        {
            // 既存のサイズ調整機能が正しく機能しないらしいので
            // 自動でサイズ調整を行う計算を作成しています。
            // 試作段階なので今後変更の可能性あり。
            // -2 は計算後の微調整のための定数です。
            int x = (cb.SelectedItem as string).Length * (int)cb.Font.Size - 2;
            cb.MaximumSize = new Size(x, cb.ClientSize.Height);
            cb.ClientSize = new Size(x, cb.ClientSize.Height);

        }

        private void DebugButton_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, @"ObjectData\Battan\Battan\ActorInfo\ActionFlagCtrl.bcsv");
            dataGridView1.DataSource = BCSVFile.OpenRead(path).BCSVDataTable;

            //セルの幅を内容に合わせて自動調整します。
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void HashTableButton_Click(object sender, EventArgs e)
        {
            //BCSVHash.FeatchHashCollectionFromWebSite();
        }

        private void RootDirectoryComboBox_Click(object sender, EventArgs e)
        {
            
        }

        private void RootDirectoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SubDirectoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxSizeTextFit(SubDirectoryComboBox.ComboBox);
        }

        private void RootDirectoryComboBox_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void RootDirectoryComboBox_TextChanged(object sender, EventArgs e)
        {
            ComboBoxSizeTextFit(RootDirectoryComboBox.ComboBox);
            SubDirectoryComboBox.Items.Clear();

            //エラーチェック
            if (RootDirectoryComboBox.SelectedItem is null      ) return;
            if (RootDirectoryComboBox.SelectedItem is not string)return;
            
            //keyの作成
            string key = (string)RootDirectoryComboBox.SelectedItem;
            if (projectRootDirectories[key].Length < 1)return;
            
            //SubDirectorySet
            BCSVComboBoxSetting SubDirectoryComboBoxSetting = new();
            string[] subDirPath = projectRootDirectories[key];
            SubDirectoryComboBoxSetting.SetComboBoxItems(SubDirectoryComboBox.ComboBox, subDirPath);
            projectSubDirectories = SubDirectoryComboBoxSetting.NameAndPathDictionary;

        }
    }
}
