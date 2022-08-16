using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System.Buffers.Binary;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.Yaz0
{
    public class Yaz0
    {
        public HeaderInfo Header { get; protected set; }
        
        public struct HeaderInfo 
        {
            public uint SectionName { get; private set; }
            public int OriginalDataSize { get; private set; }
            public int Unknown1 { get; private set; }
            public int Unknown2 { get; private set; }

            public HeaderInfo(BinaryReader br) 
            {
                SectionName      = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
                OriginalDataSize = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                Unknown1         = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                Unknown2         = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            }
        }
    }


}
