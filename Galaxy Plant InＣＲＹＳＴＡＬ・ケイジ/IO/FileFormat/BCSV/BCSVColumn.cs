using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSV
{
    internal class BCSVFieldsSection
    {
        internal uint NameHash { get; private set; }
        internal uint BitMask { get; private set; }
        internal ushort NextFieldOffset { get; private set; }
        internal byte? FieldPrimitiveType { get; private set; }

        [Flags]
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

        internal BCSVFieldsSection()
        {
            NameHash             = 0;
            BitMask              = 0;
            NextFieldOffset      = 0;
            FieldPrimitiveType   = null;
        }

        internal void Read(BinaryReader br)
        {
            NameHash             = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
            BitMask              = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
            NextFieldOffset      = BinaryPrimitives.ReadUInt16BigEndian(br.ReadBytes(2));
            FieldPrimitiveType   = br.ReadByte();
            throw new NotImplementedException("この機能はこれより先を実装していません。");
        }


    }
}
