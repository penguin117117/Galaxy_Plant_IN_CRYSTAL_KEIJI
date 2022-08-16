using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System.Buffers.Binary;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    public class RARC
    {
        public HeaderInfo Header { get; protected set; }
        
        

        public struct HeaderInfo
        {
            public uint SectionName { get; set; }
            public int FileSize { get; set; }
            public int Unknown1 { get; set; }
            public int FileDataOffset { get; set; }
            public int FileDataLength_1 { get; set; }
            public int FileDataLength_2 { get; set; }
            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }

            public const int HeaderSize = 0x20;

            public HeaderInfo(BinaryReader br) 
            {
                SectionName      = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
                FileSize         = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                Unknown1         = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                FileDataOffset   = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                FileDataLength_1 = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                FileDataLength_2 = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                Unknown2         = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                Unknown3         = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            }
        }

        
    }
}
