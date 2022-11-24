using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers.Binary;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    public class RARCEntryHeader
    {
        public int NodeLength { get; set; }
        public int FirstNodeOffset { get; set; }
        public int TotalDirectoryCount { get; set; }
        public int FirstDirectoryOffset { get; set; }
        public int StringTableLength { get; set; }
        public int StringTableOffset { get; set; }
        public int DirectoryFileNum { get; set; }
        public int Unknown4 { get; set; }
        public int Unknown5 { get; set; }

        public RARCEntryHeader() 
        {
            
        }

        public void Read(BinaryReader br) 
        {
            NodeLength           = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            FirstNodeOffset      = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            TotalDirectoryCount  = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            FirstDirectoryOffset = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            StringTableLength    = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            DirectoryFileNum     = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            Unknown4             = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            Unknown5             = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
        }
    }
}
