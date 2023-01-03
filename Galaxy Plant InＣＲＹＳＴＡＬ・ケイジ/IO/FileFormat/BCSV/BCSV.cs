using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSV
{
    internal class BCSV
    {
        internal BCSVHeader BCSVHeader { get; private set; }
        internal BCSVFieldsSection BCSVFieldsSection { get; private set; }

        internal BCSV() 
        {
            BCSVHeader= new BCSVHeader();
            BCSVFieldsSection= new BCSVFieldsSection();
        }

        internal void Read(BinaryReader br) 
        {
            BCSVHeader.Read(br);
            BCSVFieldsSection.Read(br);
        }
    }
}
