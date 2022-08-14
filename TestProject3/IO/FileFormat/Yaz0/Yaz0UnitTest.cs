using Microsoft.VisualStudio.TestTools.UnitTesting;
using Galaxy_Plant_In‚b‚q‚x‚r‚s‚`‚k_ƒPƒCƒW.IO.FileFormat.Yaz0;
using System.IO;

namespace Galaxy_Plant_In‚b‚q‚x‚r‚s‚`‚k_ƒPƒCƒWTest
{
    [TestClass]
    public class Yaz0UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string fileDir = @"E:\ƒhƒLƒ…ƒƒ“ƒg\ƒQ[ƒ€\ƒQ[ƒ€rom\Wii\iso\ISO\TakoChuTest\files\ObjectData\";
            Yaz0Decord yaz0Decord = new(fileDir + @"Abekobe2DMoveLift.arc");
            yaz0Decord.Save(fileDir + @"Abekobe2DMoveLift.arc");
            Assert.IsTrue(File.Exists(fileDir + @"Abekobe2DMoveLift.rarc"));
        }
    }
}