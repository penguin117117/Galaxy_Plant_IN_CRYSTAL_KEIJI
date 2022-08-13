using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.Yaz0
{
    public class Yaz0
    {
        public HeaderInfo Header { get; protected set; }
        
        public struct HeaderInfo 
        {
            public string SectionName { get; private set; }
            public int OriginalDataSize { get; private set; }
            public int Unknown1 { get; private set; }
            public int Unknown2 { get; private set; }

            public HeaderInfo(BinaryReader br) 
            {
                SectionName      = Calculation.Byte2Char(br);
                OriginalDataSize = Calculation.Byte2Int(br);
                Unknown1         = Calculation.Byte2Int(br);
                Unknown2         = Calculation.Byte2Int(br);
            }
        }
    }


}
