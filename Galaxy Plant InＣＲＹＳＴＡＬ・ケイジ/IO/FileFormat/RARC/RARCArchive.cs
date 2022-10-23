using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers.Binary;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System.Diagnostics;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCSectionSystem;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    /// <summary>
    /// RARCのアーカイブ情報を保持します。<br/>
    /// このクラスは継承できません。
    /// </summary>
    public sealed class RARCArchive
    {
        public RARCHeader RARCHeader { get; private set; }
        public RARCEntryHeader RARCEntryHeader { get; private set; }
        internal DirectoryNodeSection DirectoryNodeSection { get; private set; } = new();
        internal DirectoryItemSection DirectoryItemSection { get; private set; } = new();
        internal StringTableSection StringTableSection { get; private set; } = new();
        internal FileDataSection FileDataSection { get; private set; } = new();

        public Dictionary<string, byte[]> FilePathBinaryDataPairs { get; set; } = new();

        /// <summary>
        /// RARCのアーカイブ情報を保持します。<br/>
        /// このクラスは継承できません。
        /// </summary>
        /// <param name="br"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public RARCArchive(BinaryReader br) 
        {
            if (br.BaseStream is null) 
            {
                throw new NullReferenceException(nameof(br.BaseStream));
            }

            if (br.BaseStream.CanRead == false) 
            {
                throw new ArgumentException(
                    "このストリームは読み取りが出来ないかストリームが終了しています。"
                    );
            }
            
            //ヘッダーの読み込み
            RARCHeader = new(br);
            RARCEntryHeader = new(br);

            //各セクションの情報を読み込みます。
            DirectoryNodeSection.Read(br, RARCEntryHeader.NodeLength);
            DirectoryItemSection.Read(br, DirectoryNodeSection);
            StringTableSection.Read(br, RARCEntryHeader.StringTableLength);
            FileDataSection.Read(br,DirectoryNodeSection,StringTableSection);

        }
    }
}
