namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    internal class Extract
    {
        internal RARC.HeaderData Header;
        internal RARC.DataHeader dataHeader;
        internal RARC.DirNodeSection dirNodeSection;
        internal RARC.FileNodeSection fileNodeSection;
        internal string stringTable;
        internal string fileDataSection;


        public Extract(string tergetFileName)
        {
            using (FileStream fs = new(tergetFileName, FileMode.Open)) 
            {
                using (BinaryReader br = new(fs)) 
                {
                    
                };
            };
        }

        //io arc
        internal void ArchiveFileInport()
        {

        }

        internal void ArchiveFileOutport()
        {

        }

        //io file
        internal void AddFile(string TergetFileName)
        {

        }

        internal void DeleteFile(string TergetFileName)
        {

        }

        //io dir
        internal void AddDirectory(string TergetDir)
        {
            DirectoryNumbCtl(1);
        }

        internal void DeleteDirectory(string TergetDir)
        {
            DirectoryNumbCtl(-1);
        }

        private void DirectoryNumbCtl(int addvalue)
        {
            dataHeader.dirNodeNumber += (UInt32)addvalue;
            dataHeader.fileNodeNumber += (UInt32)addvalue;
        }

        //ls
        internal void LookDir(string Terget)
        {

        }
    }
}
