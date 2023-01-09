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

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.BCSVFileFormat
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

                //ハッシュテーブルからハッシュ値を取得
                string hashToName = 
                    Properties.Settings.Default.BCSVHashToTextDictionary.ContainsKey(NameHash) 
                    ? Properties.Settings.Default.BCSVHashToTextDictionary[NameHash] 
                    : NameHash.ToString();

                DataColumn.ColumnName = hashToName;
                DataColumn.MaxLength = 30;
                DataColumn.DataType = PrimType[FieldPrimitiveType];
                

                Debug.WriteLine("////////////////");
                Debug.WriteLine(NameHash.ToString("X8"));
                Debug.WriteLine(BitMask.ToString("X8"));
                Debug.WriteLine(NextFieldOffset.ToString("X4"));
                Debug.WriteLine(DataShiftAmount.ToString("X2"));
                Debug.WriteLine(Enum.GetName(typeof(PrimitiveType), FieldPrimitiveType));

                Debug.WriteLine(PrimType[FieldPrimitiveType]);
            }

            internal Type GetTest(BinaryReader br)
            {
                //Enum.GetName(, FieldPrimitiveType)
                Type b = PrimType[FieldPrimitiveType];
                Type a = Get(br,b);
                return a;
            }

            private T Get<T>(BinaryReader br,T b) 
            {
                var a = br.ReadByte;
                return b;
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

        internal static readonly Dictionary<byte, Type> PrimType = new()
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
