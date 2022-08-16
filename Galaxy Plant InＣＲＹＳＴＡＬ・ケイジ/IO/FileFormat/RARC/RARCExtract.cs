using System.Diagnostics;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    public sealed class RARCExtract : RARC
    {
        public Archive Archive { get; private set; }

        public enum ExtractType 
        {
            ExtractRead,
            ExtractFileGenerate
        }

        public RARCExtract(string targetFileName,ExtractType extractType)
        {
            if(FilePathNullCheck(targetFileName)) return;

            using (FileStream fs = new(targetFileName, FileMode.Open)) 
            {
                Read(fs);
            };
        }

        public RARCExtract(byte[] targetBinaryData, ExtractType extractType) 
        {
            using (MemoryStream ms = new(targetBinaryData))
            {
                Read(ms);
            };
        }

        private void Read(Stream stream) 
        {
            using (BinaryReader br = new(stream))
            {
                Header = new HeaderInfo(br);
                Archive = new Archive(br);
                Debug.WriteLine(br.BaseStream.Position.ToString("X"));
            };
        }

        private bool FilePathNullCheck(string targetFileName) 
        {
            if (string.IsNullOrEmpty(targetFileName)) return false;

            return true;
        }

        //io arc
        public void ArchiveFileInport()
        {

        }

        public void ArchiveFileOutport()
        {

        }

        //io file
        public void AddFile(string TergetFileName)
        {

        }

        public void DeleteFile(string TergetFileName)
        {

        }

        //io dir
        public void AddDirectory(string TergetDir)
        {
            DirectoryNumbCtl(1);
        }

        public void DeleteDirectory(string TergetDir)
        {
            DirectoryNumbCtl(-1);
        }

        private void DirectoryNumbCtl(int addvalue)
        {
            //Archive.Header.dirNodeNumber += (UInt32)addvalue;
            //Archive.fileNodeNumber += (UInt32)addvalue;
        }

        //ls
        public void LookDir(string Terget)
        {

        }
    }
}
