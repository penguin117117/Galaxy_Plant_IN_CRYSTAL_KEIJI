using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCSectionSystem
{
    internal class DirectoryNodeSection
    {
        internal DirectoryNode[] DirectoryNodes { get; private set; }

        internal DirectoryNodeSection() 
        {
            DirectoryNodes = Array.Empty<DirectoryNode>();
        }

        internal void Read(BinaryReader br, int directoryNodeLength) 
        {
            DirectoryNodes = new DirectoryNode[directoryNodeLength];
            for (int entryIndex = 0; entryIndex < directoryNodeLength; entryIndex++)
            {
                DirectoryNodes[entryIndex] = DirectoryNode.Read(br);
            }
            BinarySystem.PaddingSkip(br.BaseStream);
        }
    }
}
