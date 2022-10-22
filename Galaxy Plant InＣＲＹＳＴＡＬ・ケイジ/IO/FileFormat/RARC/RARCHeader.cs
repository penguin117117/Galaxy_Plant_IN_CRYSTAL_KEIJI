using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System.Buffers.Binary;
using System.Text;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    /// <summary>
    /// RARCファイルのヘッダー情報を格納するクラス。<br/>
    /// バイトの長さは 0x20 です。
    /// </summary>
    public class RARCHeader
    {
        public uint SectionName { get; private set; }
        public int FileSize { get; set; }
        public int Unknown1 { get; set; }
        public int FileDataOffset { get; set; }
        public int FileDataLength_1 { get; set; }
        public int FileDataLength_2 { get; set; }
        public int Unknown2 { get; set; }
        public int Unknown3 { get; set; }

        public const int HeaderSize = 0x20;

        public RARCHeader(BinaryReader br)
        {
            SectionName      = BinaryPrimitives.ReadUInt32BigEndian(br.ReadBytes(4));
            FileSize         = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            Unknown1         = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            FileDataOffset   = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            FileDataLength_1 = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            FileDataLength_2 = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            Unknown2         = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));
            Unknown3         = BinaryPrimitives.ReadInt32BigEndian(br.ReadBytes(4));

            if (!IsRARC())
            {
                byte[] littleEndian = BitConverter.GetBytes(SectionName);
                byte[] bigEndian = littleEndian.Reverse().ToArray();
                throw new DataMisalignedException(
                    $"このファイルは、「RARCファイル」ではなく {Encoding.ASCII.GetString(bigEndian)}ファイルです。"
                    );
            }
        }

        private bool IsRARC() 
        {
            return SectionName == 0x52415243;
        }
    }
}
