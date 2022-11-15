using Microsoft.VisualStudio.TestTools.UnitTesting;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.Yaz0;
using System.IO;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジTest
{
    [TestClass]
    public class Yaz0UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string fileDir = @"E:\ドキュメント\ゲーム\ゲームrom\Wii\iso\ISO\TakoChuTest\files\ObjectData\";
            Yaz0Decord yaz0Decord = new(fileDir + @"Abekobe2DMoveLift.arc");
            yaz0Decord.Save(fileDir + @"Abekobe2DMoveLift.arc");
            Assert.IsTrue(File.Exists(fileDir + @"Abekobe2DMoveLift.rarc"));
        }
    }
}