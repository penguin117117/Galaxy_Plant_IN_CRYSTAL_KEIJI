using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers.Binary;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    public class EntryItem
    {
        public short ID { get; private set; }
        public short Hash { get; private set; }
        public ushort FileType { get; private set; }
        public ushort NameOffset { get; private set; }

    }
}
