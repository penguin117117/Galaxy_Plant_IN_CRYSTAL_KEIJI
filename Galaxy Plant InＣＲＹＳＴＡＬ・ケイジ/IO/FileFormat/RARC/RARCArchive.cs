using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers.Binary;
using Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.Util;
using System.Diagnostics;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO.FileFormat.RARC
{
    public class RARCArchive : IDisposable
    {
        public RARCHeader RARCHeader { get; private set; }
        public RARCEntryHeader RARCEntryHeader { get; private set; }
        public EntryInfo[] EntriesInfo { get; private set; }
        public ReadOnlyCollection<RARCArchiveEntry> Entries { get; }
        private Stream _stream;

        public RARCArchive(Stream stream) 
        {
            stream = stream ?? throw new ArgumentNullException(nameof(stream));
            if (!stream.CanRead) throw new ArgumentException("このストリームは読み取りが出来ないかストリームが終了しています。");

            

            _stream = stream;
            using BinaryReader br = new(_stream);
            RARCHeader = new(br);
            RARCEntryHeader = new(br);

            EntriesInfo = new EntryInfo[RARCEntryHeader.NodeLength];

            for (int entryIndex = 0; entryIndex < RARCEntryHeader.NodeLength; entryIndex++) 
            {
                EntriesInfo[entryIndex] = EntryInfo.Read(br);
            }

            BinarySystemPadding.SkipEndPosition(br.BaseStream);
            Debug.WriteLine("EntriesInfoEndPosition: " + br.BaseStream.Position.ToString("X"));

            foreach (EntryInfo entryInfo in EntriesInfo) 
            {
                for (int entryIndex = 0; entryIndex < entryInfo.FolderDirectoryCount; entryIndex++) 
                {
                    
                }
            }
        }

        public RARCArchiveEntry CreateEntry(string entryName) 
        {
            throw new NotImplementedException();
        }

        public RARCArchiveEntry? GetEntry(string entryName) 
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _stream.Close();
        }
    }
}
