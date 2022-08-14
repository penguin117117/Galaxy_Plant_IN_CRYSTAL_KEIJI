using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.rarc;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.rarc
{
    internal class rarc
    {
        internal rarcFormat.header Header;
        internal rarcFormat.dataHeader dataHeader;
        internal rarcFormat.dirNodeSection dirNodeSection;
        internal rarcFormat.fileNodeSection fileNodeSection;
        internal string stringTable;
        internal string fileDataSection;


        public rarc(string tergetFileName)
        {

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
