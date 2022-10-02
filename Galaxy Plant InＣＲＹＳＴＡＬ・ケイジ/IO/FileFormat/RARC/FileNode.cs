using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers.Binary;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{

    public class FileNode
    {
        public short ID { get; private set; }
        public short Hash { get; private set; }
        public RARCFileNodeType FileType { get; private set; }
        public byte BytePadding { get; private set; }
        public ushort NameOffset { get; private set; }
        /// <summary>
        /// <see cref="FileType"/>がFileならOffsetとファイルサイズが読み込まれます。<br/>
        /// <see cref="FileType"/>がDirectoryならIndexと10の定数が読み込まれます。
        /// </summary>
        public (int, int) Argments { get; private set; }
        public int Padding { get; private set; }

        public FileNode(BinaryReader br) 
        {
            ID = BinaryPrimitives.ReadInt16BigEndian(br.ReadBytes(2));
            Hash = BinaryPrimitives.ReadInt16BigEndian(br.ReadBytes(2));
            FileType = (RARCFileNodeType)br.ReadByte();
            BytePadding = br.ReadByte();
            NameOffset = BinaryPrimitives.ReadUInt16BigEndian(br.ReadBytes(2));
            Argments = (BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4)), BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4)));
            Padding = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
        }
    }

    public enum RARCFileNodeType : byte 
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
