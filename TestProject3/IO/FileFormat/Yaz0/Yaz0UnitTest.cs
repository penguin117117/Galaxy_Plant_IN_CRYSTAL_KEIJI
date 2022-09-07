using Microsoft.VisualStudio.TestTools.UnitTesting;
using Galaxy_Plant_In�b�q�x�r�s�`�k_�P�C�W.IO.FileFormat.Yaz0;
using System.IO;

namespace Galaxy_Plant_In�b�q�x�r�s�`�k_�P�C�WTest
{
    [TestClass]
    public class Yaz0UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string fileDir = @"E:\�h�L�������g\�Q�[��\�Q�[��rom\Wii\iso\ISO\TakoChuTest\files\ObjectData\";
            Yaz0Decord yaz0Decord = new(fileDir + @"Abekobe2DMoveLift.arc");
            yaz0Decord.Save(fileDir + @"Abekobe2DMoveLift.arc");
            Assert.IsTrue(File.Exists(fileDir + @"Abekobe2DMoveLift.rarc"));
        }
    }
}