using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI;
using System.Diagnostics;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSV;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ
{
    public partial class GalaxySelectForm : Form
    {
        public GalaxySelectForm()
        {
            InitializeComponent();
            if (Properties.Settings.Default.GalaxyProjectPath == string.Empty)
            {
                Game.Version = Game.GameVersion.None;
            }
            else 
            {
                SetGalaxyNameTreeView();
            }

            if (Properties.Settings.Default.BCSVHashToTextDictionary == default)
            {
                BCSVHash.FeatchHashCollectionFromWebSite();
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GalaxyProjectFolder.Open();
            SetGalaxyNameTreeView();
        }

        private void SetGalaxyNameTreeView() 
        {
            if (((Game.GameVersion)Properties.Settings.Default.GameVersion | Game.GameVersion.None) == Game.GameVersion.None) return;
            GalaxyNameTreeView.Nodes.Clear();
            var dirctoriesPath = Directory.GetDirectories(Path.Combine(Properties.Settings.Default.GalaxyProjectPath, "StageData"));
            foreach (var dir in dirctoriesPath)
            {
                foreach (var file in Directory.GetFiles(dir))
                {

                    if (Path.GetFileNameWithoutExtension(file).Length < 8) continue;
                    var foundGalaxyScenarioIndex = Path.GetFileNameWithoutExtension(file).IndexOf("Scenario");
                    if (foundGalaxyScenarioIndex < 0) continue;
                    GalaxyNameTreeView.Nodes.Add(string.Concat(Path.GetFileNameWithoutExtension(file).Take(foundGalaxyScenarioIndex)), string.Concat(Path.GetFileNameWithoutExtension(file).Take(foundGalaxyScenarioIndex)));
                }

            }
        }

        private void DebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IODebugForm ioDebugForm = new();
            ioDebugForm.ShowDialog();
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemSettingForm systemSettingForm = new SystemSettingForm();
            systemSettingForm.ShowDialog();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InformationForm informaItionForm = new InformationForm();
            informaItionForm.ShowDialog();
        }

        private void GalaxyNameTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name == null) 
            {
                MessageBox.Show("Null");
                return;
            }

            string selectedGalaxyName = e.Node.Name;

            GalaxyEditorForm galaxyEditorForm = new GalaxyEditorForm(selectedGalaxyName);
            galaxyEditorForm.ShowDialog();
        }

        private void BCSVEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BCSVEditorForm bCSVEditorForm = new BCSVEditorForm();
            bCSVEditorForm.ShowDialog();
        }
    }
}