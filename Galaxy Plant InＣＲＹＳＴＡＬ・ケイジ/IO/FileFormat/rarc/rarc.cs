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

        internal void FileInport(string tergetFileName)
        {
        }
    }
}
