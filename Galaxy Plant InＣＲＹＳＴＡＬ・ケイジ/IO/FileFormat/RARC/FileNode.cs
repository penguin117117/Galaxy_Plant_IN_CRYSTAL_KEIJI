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
        public ushort FileType { get; private set; }
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
            FileType = BinaryPrimitives.ReadUInt16BigEndian(br.ReadBytes(2));
            NameOffset = BinaryPrimitives.ReadUInt16BigEndian(br.ReadBytes(2));
            Argments = (BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4)), BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4)));
            Padding = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
        }
    }
}
