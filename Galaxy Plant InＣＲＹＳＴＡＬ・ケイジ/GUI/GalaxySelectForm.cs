using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO;


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
            GalaxyProjectFolder galaxyProjectFolder = new();
        }

        private void DebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yaz0のデバッグ
            var yaz0FilePath = @"E:\ドキュメント\ゲーム\ゲームrom\Wii\iso\ISO\TakoChuTest\files\ObjectData\Abekobe2DMoveLift.arc";
            IO.FileFormat.Yaz0.Yaz0Decord yaz0Decord = new IO.FileFormat.Yaz0.Yaz0Decord(yaz0FilePath);
            yaz0Decord.Save(yaz0FilePath);
        }
    }
}