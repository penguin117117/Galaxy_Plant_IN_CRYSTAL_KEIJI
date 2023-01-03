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
        internal BCSVColumns BCSVColumns { get; private set; }

        internal BCSV() 
        {
            BCSVHeader   = new BCSVHeader();
            BCSVColumns  = new BCSVColumns();
        }

        internal void Read(BinaryReader br) 
        {
            BCSVHeader.Read(br);
            BCSVColumns.Read(br ,BCSVHeader.ColumnsCount);
        }

        private void ReadColumns() 
        {
            
        }
    }
}
