using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers.Binary;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    /// <summary>
    /// 4文字,4byte,2byte,2byte,4byteで区切られるセクション。
    /// ディレクトリの情報を格納します。
    /// </summary>
    public class DirectoryNode
    {
        /// <summary>
        /// ディレクトリ名の先頭4文字を大文字で表す。4文字に満たない場合は空白文字で埋められる。
        /// </summary>
        public char[] EntryShortName { get; private set; }
        public int StringTopOffset { get; private set; }
        public ushort StringHash { get; private set; }
        public short FolderDirectoryCount { get; private set; }
        public int FirstDirectoryIndex { get; private set; }

        public static DirectoryNode Read(BinaryReader br)
        {
            return new DirectoryNode
            {
                EntryShortName       = br.ReadChars(4),
                StringTopOffset      = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4)),
                StringHash           = BinaryPrimitives.ReadUInt16BigEndian(br.ReadBytes(2)),
                FolderDirectoryCount = BinaryPrimitives.ReadInt16BigEndian(br.ReadBytes(2)),
                FirstDirectoryIndex  = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4))
            };
        }
    }
}
