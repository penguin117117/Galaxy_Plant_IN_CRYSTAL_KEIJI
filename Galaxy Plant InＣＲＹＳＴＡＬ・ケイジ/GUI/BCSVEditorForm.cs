using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSV;
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
    public partial class BCSVEditorForm : Form
    {
        public BCSVEditorForm()
        {
            InitializeComponent();
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
    }
}
