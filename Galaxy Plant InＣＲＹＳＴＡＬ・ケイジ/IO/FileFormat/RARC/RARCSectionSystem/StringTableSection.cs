using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCSectionSystem
{
    internal class StringTableSection
    {
        internal long StringDataTablePosition { get; private set; }
        internal byte[] StringData { get; private set; } = Array.Empty<byte>();

        /// <summary>
        /// ルートディレクトリの名前のオフセットは固定で5になる。
        /// </summary>
        internal const int RootDirectoryNameIndex = 5;

        internal void Read(BinaryReader br, int stringDataTableLength) 
        {
            //String Table
            StringDataTablePosition = br.BaseStream.Position;
            StringData = br.ReadBytes(stringDataTableLength);
        }

        internal string ReadNullEnd(int startPosition)
        {
            MemoryStream ms = new(StringData);
            BinaryReader br = new(ms);
            return BinarySystem.ReadSeekStringNullEndAndSeekFix(br,startPosition);
        }

        internal string ReadRootName() 
        {
            return ReadNullEnd(RootDirectoryNameIndex);
        }
    }
}
