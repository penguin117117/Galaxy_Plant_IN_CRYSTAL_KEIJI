using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    public class RARC
    {
        public class HeaderData
        {
            public string? Magic { get; set; }
            public int FileSize { get; set; }
            public int Unknown1 { get; set; }
            public int FileDataOffset { get; set; }
            public int FileDataLength_1 { get; set; }
            public int FileDataLength_2 { get; set; }
            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }

            public const int HeaderSize = 0x20;

            public void Read(BinaryReader br)
            {
                Magic            = Calculation.Byte2Char(br);
                FileSize         = Calculation.Byte2Int(br);
                Unknown1         = Calculation.Byte2Int(br);
                FileDataOffset   = Calculation.Byte2Int(br);
                FileDataLength_1 = Calculation.Byte2Int(br);
                FileDataLength_2 = Calculation.Byte2Int(br);
                Unknown2         = Calculation.Byte2Int(br);
                Unknown3         = Calculation.Byte2Int(br);
            }
        }

        public struct DataHeader //0x20
        {
            public UInt32 dirNodeNumber;  //0x00
            public UInt32 dirNodeOffset;  //0x04
            public UInt32 fileNodeNumber; //0x08
            public UInt32 fileNodeOffset; //0x0c
            public UInt32 stringNodeNumber;   //0x10
            public UInt32 stringNodeOffset;   //0x14
            public UInt16 nextAvailableFileIndex; //0x18
            public char keepIDSync;  //0x1a
            public char padding1;    //0x1b
            public char padding2;
            public char padding3;
            public char padding4;
            public char padding5;
        }

        public struct DirNodeSection //0x10
        {
            public UInt32 nodeNameFirst4String;    //0x00
            public UInt32 nodeNameOffsetIntoStringTable;   //0x04
            public UInt16 nameHash;    //0x08
            public UInt16 fileNodeEntryNumb;  //0x0a
            public UInt32 fileNodeOffset; //0x0c
        }

        public struct FileNodeSection //0x10
        {
            public UInt16 nodeIndex;  //0x00
            public UInt16 nameHash;   //0x02
            public char nodeAttributesFlag;  //0x04
            public char padding; //0x05
            public UInt16 nodeNameOffsetIntoStringTable;  //0x06
            public UInt32 dataIndex;  //0x08
            public UInt32 sizeForDataindex;   //0x0c
        }
    }
}
