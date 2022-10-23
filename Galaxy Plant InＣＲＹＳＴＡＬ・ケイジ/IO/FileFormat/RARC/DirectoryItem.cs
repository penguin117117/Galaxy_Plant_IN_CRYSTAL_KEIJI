using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers.Binary;
using System.Diagnostics;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    /// <summary>
    /// RARCにアーカイブされているフォルダとファイルの情報を格納しているクラス。
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// ファイルのIDを格納します。サブディレクトリの場合は、0xFFFF
        /// </summary>
        public short ID { get; private set; }
        /// <summary>
        /// ファイル名のハッシュ値を格納します。
        /// </summary>
        public short Hash { get; private set; }
        /// <summary>
        /// <see cref="RARCEntryType.File"/> または <see cref="RARCEntryType.Directory"/> を判別します。
        /// </summary>
        public RARCEntryType EntryType { get; private set; }
        public byte BytePadding { get; private set; }
        public ushort NameOffset { get; private set; }
        /// <summary>
        /// <see cref="EntryType"/> が <see cref="RARCEntryType.File"/> ならOffsetとファイルサイズが読み込まれます。<br/>
        /// <see cref="EntryType"/> が <see cref="RARCEntryType.Directory"/> ならIndexと10の定数が読み込まれます。
        /// </summary>
        public (uint, uint) Argments { get; private set; }
        public int Padding { get; private set; }

        public DirectoryItem(BinaryReader br) 
        {
            ID = BinaryPrimitives.ReadInt16BigEndian(br.ReadBytes(2));
            Hash = BinaryPrimitives.ReadInt16BigEndian(br.ReadBytes(2));
            EntryType = (RARCEntryType)br.ReadByte();
            BytePadding = br.ReadByte();
            NameOffset = BinaryPrimitives.ReadUInt16BigEndian(br.ReadBytes(2));
            Argments = (BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4)), BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4)));
            Padding = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));

            //ParamWatcher();
        }

        private void ParamWatcher() 
        {
            //Debug.WriteLine("/////////////////////////////////////////////////");
            Debug.WriteLine("ID: "+ID.ToString("X"));
            Debug.WriteLine("Hash: "+Hash.ToString("X"));
            Debug.WriteLine("EntryType: "+EntryType.ToString("X"));
            Debug.WriteLine("NameOffset: "+NameOffset.ToString("X"));
            Debug.WriteLine("Arg1: "+Argments.Item1.ToString("X"));
            Debug.WriteLine("Arg2: "+Argments.Item2.ToString("X"));
            Debug.WriteLine("/////////////////////////////////////////////////");
        }
    }

    public enum RARCEntryType : byte 
    {
        File = 0x01,
        Directory = 0x02,
        Compressed = 0x04,
        PreloadToMRAM = 0x10,
        PreloadToARAM = 0x20,
        LoadFromDVD = 0x40,
        Yaz0Compressed = 0x80
    }
}
