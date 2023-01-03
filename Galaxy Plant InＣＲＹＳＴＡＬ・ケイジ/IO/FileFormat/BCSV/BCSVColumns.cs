using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSV
{
    internal class BCSVColumns
    {
        internal struct BCSVColumn 
        {
            internal uint NameHash { get; private set; }
            internal uint BitMask { get; private set; }
            internal ushort NextFieldOffset { get; private set; }
            internal byte DataShiftAmount { get; private set; }
            internal byte? FieldPrimitiveType { get; private set; }

            internal BCSVColumn(BinaryReader br) 
            {
                NameHash             = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
                BitMask              = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
                NextFieldOffset      = BinaryPrimitives.ReadUInt16BigEndian(br.ReadBytes(2));
                DataShiftAmount      = br.ReadByte();
                FieldPrimitiveType   = br.ReadByte();
            }
        }
        
        internal BCSVColumn[]? Columns { get; private set; }
        
        internal enum PrimitiveType : byte
        {
            LONG             = 0x00,
            STRING           = 0x01,
            FLOAT            = 0x02,
            LONG_2           = 0x03,
            SHORT            = 0x04,
            CHAR             = 0x05,
            STRING_OFFSET    = 0x06
        }

        internal BCSVColumns()
        {
            Columns = null;
        }

        internal void Read(BinaryReader br,uint columnsSize)
        {
            Columns = new BCSVColumn[columnsSize];

            for (int i = 0; i < columnsSize; i++) 
            {
                Columns[i] = new BCSVColumn(br);
            }

            Debug.WriteLine($"BCSVColumnsSectionEnd : {br.BaseStream.Position.ToString("X")}");

            
            throw new NotImplementedException("この先の処理は実装していません");
        }


    }
}
