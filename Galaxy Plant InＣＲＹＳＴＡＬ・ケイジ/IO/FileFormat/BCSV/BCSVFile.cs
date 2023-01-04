using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSV
{
    internal class BCSVFile
    {
        internal static void ReadEntries(byte[] binaryData) 
        {
            using MemoryStream ms = new(binaryData);
            using BinaryReader br = new(ms);

            BCSV bcsv= new();
            bcsv.Read(br);
        }

        internal static void ReadEntries(string filePath)
        {
            if (!File.Exists(filePath)) return;

            using FileStream fs = new(filePath,FileMode.Open);
            using BinaryReader br = new(fs);

            BCSV bcsv = new();
            bcsv.Read(br);
        }

        internal static BCSV OpenRead(string filePath) 
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException();

            using FileStream fs = new(filePath, FileMode.Open);
            using BinaryReader br = new(fs);

            BCSV bcsv = new();
            bcsv.Read(br);

            return bcsv;
        }
    }
}
