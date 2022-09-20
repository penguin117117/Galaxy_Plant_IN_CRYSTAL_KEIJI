using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    public static class RARCFile
    {
        public static void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName) 
        {
        
        }

        public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName) 
        {
            if (!File.Exists(sourceArchiveFileName)) 
            {
                Debug.WriteLine($"このアーカイブファイルは存在しません\n{sourceArchiveFileName}");
                return;
            }

            using FileStream fs = new(sourceArchiveFileName, FileMode.Open);
            RARCArchive rarcArchive = new(fs);
            //foreach (RARCArchiveEntry entry in rarcArchive.Entries) 
            //{

            //}
        }

        public static void ExtractToDirectory(byte[] sourceArchiveBinaries, string destinationDirectoryName)
        {


            using MemoryStream ms = new(sourceArchiveBinaries);
            RARCArchive rarcArchive = new(ms);
            //foreach (RARCArchiveEntry entry in rarcArchive.Entries) 
            //{

            //}
        }

        public static RARCArchive Open(string arciveFileName) 
        {
            throw new NotImplementedException();
        }

        public static RARCArchive OpenRead(string arciveFileName) 
        {
            using (FileStream fs = new(arciveFileName, FileMode.Open))
            {
                return new RARCArchive(fs);
            };
        }

        public static RARCArchive OpenRead(byte[] arciveBinaries)
        {
            using (MemoryStream ms = new(arciveBinaries))
            {
                return new RARCArchive(ms);
            };
        }
    }
}
