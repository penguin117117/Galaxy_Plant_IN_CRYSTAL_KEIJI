using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers.Binary;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    public class DirectoryNode
    {
        /// <summary>
        /// ディレクトリ名の先頭4文字を大文字で表す。4文字に満たない場合は末尾を空白文字で埋める。
        /// </summary>
        public char[] EntryNameShort { get; private set; } = new char[entryNameShortSize];
        public int DirectoryNameOffset { get; private set; }
        public ushort StringHash { get; private set; }
        public short DirectoryNodeEntriesCount { get; private set; }
        public int FirstDirectoryIndex { get; private set; }

        private const byte entryNameShortSize = 4; 

        public string CurrentDirectoryName = string.Empty;
        public string ParentDirectoryName = string.Empty;
        public List<DirectoryItem> DirectoryItems = new();
        public Dictionary<(string,uint), byte[]>IncludeFileNameBinaryPairs = new();
        public List<string> SubDirectories = new();

        public static DirectoryNode Read(BinaryReader br)
        {
            return new DirectoryNode
            {
                EntryNameShort       = br.ReadChars(entryNameShortSize),
                DirectoryNameOffset  = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4)),
                StringHash           = BinaryPrimitives.ReadUInt16BigEndian(br.ReadBytes(2)),
                DirectoryNodeEntriesCount = BinaryPrimitives.ReadInt16BigEndian(br.ReadBytes(2)),
                FirstDirectoryIndex  = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4))
            };
        }
    }
}
