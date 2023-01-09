using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI.ControlsSetting.ProjectControls;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSVFileFormat;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCDirectoryEdit;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.Yaz0;
using System.Diagnostics;
using System.Windows.Forms;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI
{
    public partial class BCSVEditorForm : Form
    {
        private Dictionary<string, string[]> projectRootDirectories;
        private Dictionary<string, string[]> projectSubDirectories;
        private List<BCSV> bcsvList { get; set; }

        public BCSVEditorForm()
        {
            InitializeComponent();
            projectRootDirectories = new();
            projectSubDirectories = new();
            bcsvList = new List<BCSV>();

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
            if (noneToolStripMenuItem.Text == "None") return;
            var path = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, noneToolStripMenuItem.Text);

            if (!File.Exists(path)) return;
            Debug.WriteLine((Path.GetExtension(path)));
            if (!(Path.GetExtension(path) == ".arc")) return;

            Yaz0Decord yaz0Decord = new(path);

            var rarc = RARCFile.OpenRead(yaz0Decord.BinaryData);
            RARCArchiveExtract.ToDictionary(rarc, path);


            Debug.WriteLine(rarc.FilePathBinaryDataPairs.Count());


            foreach (var filePathBinaryDataPair in rarc.FilePathBinaryDataPairs)
            {
                if (Path.GetExtension(filePathBinaryDataPair.Key) == ".bcsv")
                {
                    BCSV bcsv = BCSVFile.OpenRead(filePathBinaryDataPair.Value);
                    bcsvList.Add(bcsv);
                    var fileName = Path.GetFileName(filePathBinaryDataPair.Key);

                    TabPage tabPage = new()
                    {
                        Name = fileName + "TabPage",
                        Text = fileName,
                        Tag = bcsv
                    };

                    DataGridView dataGridView = new()
                    {
                        DataSource = bcsv.DataTable,
                        Dock= DockStyle.Fill,
                        //セルの幅を内容に合わせて自動調整します。
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
                    };

                    //コントロールの追加順序は変えない事
                    BCSVSheetTabControl.Controls.Add(tabPage);
                    tabPage.Controls.Add(dataGridView);

                    //デバッグの際はここにbreak;を
                    //入れるとファイルを一つのみ実行できます
                    break;
                }
            }
            //var path = Path.Combine(Properties.Settings.Default.GalaxyProjectPath, @"ObjectData\Battan\Battan\ActorInfo\ActionFlagCtrl.bcsv");



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
            noneToolStripMenuItem.Text = Path.Combine(RootDirectoryComboBox.Text,SubDirectoryComboBoxNo1.Text);
            ComboBoxSizeTextFit(SubDirectoryComboBoxNo1.ComboBox);
            SubDirectoryComboBoxNo2.Items.Clear();

            //エラーチェック
            if (SubDirectoryComboBoxNo1.SelectedItem is null) return;
            if (SubDirectoryComboBoxNo1.SelectedItem is not string) return;

            //keyの作成
            string key = (string)SubDirectoryComboBoxNo1.SelectedItem;
            
            if (projectSubDirectories[key].Length < 1) return;

            if (projectSubDirectories[key].Length == 1) 
            {
                if (File.Exists(projectSubDirectories[key][0])) 
                {
                    SubDirectoryComboBoxNo2.Visible = false;
                    return;
                }

                
            }

            SubDirectoryComboBoxNo2.Visible = true;

            //SubDirectorySet
            BCSVComboBoxSetting SubDirectoryComboBoxNo2Setting = new();
            string[] subDirPath = projectSubDirectories[key];
            SubDirectoryComboBoxNo2Setting.SetComboBoxItems(SubDirectoryComboBoxNo2.ComboBox, subDirPath);
            //projectSubDirectories = SubDirectoryComboBoxSetting.NameAndPathDictionary;
        }

        private void RootDirectoryComboBox_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void RootDirectoryComboBox_TextChanged(object sender, EventArgs e)
        {
            noneToolStripMenuItem.Text = RootDirectoryComboBox.Text;
            ComboBoxSizeTextFit(RootDirectoryComboBox.ComboBox);
            SubDirectoryComboBoxNo1.Items.Clear();

            //エラーチェック
            if (RootDirectoryComboBox.SelectedItem is null      ) return;
            if (RootDirectoryComboBox.SelectedItem is not string)return;
            
            //keyの作成
            string key = (string)RootDirectoryComboBox.SelectedItem;
            if (projectRootDirectories[key].Length < 1)return;
            
            //SubDirectorySet
            BCSVComboBoxSetting SubDirectoryComboBoxSetting = new();
            string[] subDirPath = projectRootDirectories[key];
            SubDirectoryComboBoxSetting.SetComboBoxItems(SubDirectoryComboBoxNo1.ComboBox, subDirPath);
            projectSubDirectories = SubDirectoryComboBoxSetting.NameAndPathDictionary;

        }

        private void SubDirectoryComboBoxNo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxSizeTextFit(SubDirectoryComboBoxNo2.ComboBox);
            noneToolStripMenuItem.Text = Path.Combine(RootDirectoryComboBox.Text, SubDirectoryComboBoxNo1.Text);
            noneToolStripMenuItem.Text = Path.Combine(noneToolStripMenuItem.Text,SubDirectoryComboBoxNo2.Text);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
