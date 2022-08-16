using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.GUI;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ
{
    public partial class GalaxySelectForm : Form
    {
        public GalaxySelectForm()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GalaxyProjectFolder.Open();
        }

        private void DebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IODebugForm ioDebugForm = new();
            ioDebugForm.ShowDialog();
        }
    }
}