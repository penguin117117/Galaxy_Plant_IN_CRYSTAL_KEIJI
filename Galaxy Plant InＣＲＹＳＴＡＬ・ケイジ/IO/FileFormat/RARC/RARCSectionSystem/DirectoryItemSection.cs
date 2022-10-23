using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC.RARCSectionSystem
{
    internal class DirectoryItemSection
    {
        internal void Read(BinaryReader br, DirectoryNodeSection directoryNodeSection) 
        {
            foreach (DirectoryNode directoryNode in directoryNodeSection.DirectoryNodes)
            {
                directoryNode.DirectoryItems = ReadDirectoryItems(br, directoryNode.DirectoryNodeEntriesCount);
            }
            BinarySystem.PaddingSkip(br.BaseStream);
        }

        private List<DirectoryItem> ReadDirectoryItems(BinaryReader br, short folderDirectoryCount)
        {
            //FileNodeSection
            List<DirectoryItem> rarcEntries = new();
            for (int entryIndex = 0; entryIndex < folderDirectoryCount; entryIndex++)
            {
                rarcEntries.Add(new DirectoryItem(br));
            }

            return rarcEntries;
        }
    }
}
