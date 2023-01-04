using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSV
{
    internal class BCSVColumns
    {
        //TODO: ハッシュ値から文字列への変換処理の実装
        internal struct BCSVColumn
        {
            internal uint NameHash { get; private set; }
            internal uint BitMask { get; private set; }
            internal ushort NextFieldOffset { get; private set; }
            internal byte DataShiftAmount { get; private set; }
            internal byte FieldPrimitiveType { get; private set; }

            internal DataColumn DataColumn { get; private set; }

            internal BCSVColumn(BinaryReader br)
            {
                DataColumn = new DataColumn();
                NameHash = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
                BitMask = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
                NextFieldOffset = BinaryPrimitives.ReadUInt16BigEndian(br.ReadBytes(2));
                DataShiftAmount = br.ReadByte();
                FieldPrimitiveType = br.ReadByte();

                DataColumn.ColumnName = NameHash.ToString();
                DataColumn.DataType = PrimType[FieldPrimitiveType];

                Debug.WriteLine("////////////////");
                Debug.WriteLine(NameHash.ToString("X8"));
                Debug.WriteLine(BitMask.ToString("X8"));
                Debug.WriteLine(NextFieldOffset.ToString("X4"));
                Debug.WriteLine(DataShiftAmount.ToString("X2"));
                Debug.WriteLine(Enum.GetName(typeof(PrimitiveType), FieldPrimitiveType));
            }

            //https://kuribo64.net/wiki/?page=BCSV#The_fields
            /// <summary>
            /// <see cref="string"/>型の名前からハッシュ値を取得します。
            /// </summary>
            /// <param name="columnName"></param>
            /// <returns><see cref="uint"/> Hash</returns>
            public static uint NameToHash(string columnName)
            {
                uint ret = 0;
                foreach (char ch in columnName)
                {
                    ret *= 0x1F;
                    ret += ch;
                }
                return ret;
            }
        }

        internal BCSVColumn[]? Columns { get; private set; }

        internal enum PrimitiveType : byte
        {
            LONG = 0x00,
            STRING = 0x01,
            FLOAT = 0x02,
            LONG_2 = 0x03,
            SHORT = 0x04,
            CHAR = 0x05,
            STRING_OFFSET = 0x06
        }

        internal static readonly Dictionary<byte, Type> PrimType = new Dictionary<byte, Type>()
        {
            { 0x00 , typeof(long) },
            { 0x01 , typeof(string) },
            { 0x02 , typeof(float) },
            { 0x03 , typeof(long) },
            { 0x04 , typeof(short) },
            { 0x05 , typeof(char) },
            { 0x06 , typeof(string) }
        };

        internal BCSVColumns()
        {
            Columns = null;
        }

        internal DataColumn[] Read(BinaryReader br,uint columnsSize)
        {
            DataColumn[] dataColumns = new DataColumn[columnsSize];
            Columns = new BCSVColumn[columnsSize];

            for (int i = 0; i < columnsSize; i++) 
            {
                Columns[i] = new BCSVColumn(br);
                dataColumns[i] = Columns[i].DataColumn;
            }

            Debug.WriteLine($"BCSVColumnsSectionEnd : {br.BaseStream.Position.ToString("X")}");

            return dataColumns;
            throw new NotImplementedException("この先の処理は実装していません");
        }

        
    }
}
