using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSV
{
    internal class BCSVHeader
    {
        internal uint EntryCount { get; private set; }
        internal uint ColumnsCount { get; private set; }
        internal uint EntryDataSectionOffset { get; private set; }
        internal uint EntryByteSize { get; private set; }

        internal BCSVHeader() 
        { 
            EntryCount= 0;
            ColumnsCount= 0;
            EntryDataSectionOffset= 0;
            EntryByteSize= 0;
        }

        internal void Read(BinaryReader br) 
        {
            EntryCount = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
            ColumnsCount = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
            EntryDataSectionOffset = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
            EntryByteSize = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
        }
    }
}
