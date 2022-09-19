using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    public class Archive
    {
        public HeaderInfo Header { get; private set; }
        public DirNodeSection? DirectoryNodes { get; protected set; }
        public FileNodeSection? FileNodes { get; protected set; }
        public string? StringTable { get; protected set; }
        public string? FileDataSection { get; protected set; }

        public Archive(BinaryReader br) 
        {
            Header = new HeaderInfo(br);
        }

        public class HeaderInfo
        {
            public int NodeLength { get; set; }
            public int FirstNodeOffset { get; set; }
            public int TotalDirectoryCount { get; set; }
            public int FirstDirectoryOffset { get; set; }
            public int StringTableLength { get; set; }
            public int StringTableOffset { get; set; }
            public short DirectoryFileNum { get; set; }
            public short Unknown4 { get; set; }
            public int Unknown5 { get; set; }

            public HeaderInfo(BinaryReader br)
            {
                NodeLength           = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                FirstNodeOffset      = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                TotalDirectoryCount  = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                FirstDirectoryOffset = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                StringTableLength    = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                StringTableOffset    = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
                DirectoryFileNum     = BinaryPrimitives.ReadInt16BigEndian(br.ReadBytes(2));
                Unknown4             = BinaryPrimitives.ReadInt16BigEndian(br.ReadBytes(2));
                Unknown5             = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            }
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
