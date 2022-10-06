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
        public DirectoryNode[] DirectoryNodes { get; private set; }
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

            //DirectoryNodeSection
            DirectoryNodes = new DirectoryNode[RARCEntryHeader.NodeLength];
            for (int entryIndex = 0; entryIndex < RARCEntryHeader.NodeLength; entryIndex++) 
            {
                DirectoryNodes[entryIndex] = DirectoryNode.Read(br);
            }
            BinarySystem.PaddingSkip(br.BaseStream);
            Debug.WriteLine("DirectoryNodeSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            //FileNodeSection
            List<FileNode> FileNodes = new();
            foreach (DirectoryNode entryInfo in DirectoryNodes) 
            {
                for (int entryIndex = 0; entryIndex < entryInfo.FolderDirectoryCount; entryIndex++) 
                {
                    FileNodes.Add(new FileNode(br));
                }
            }
            BinarySystem.PaddingSkip(br.BaseStream);
            Debug.WriteLine("FileNodeSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            //String Table
            Debug.WriteLine($"StringTableSize::{RARCEntryHeader.StringTableLength:X}");
            for (int i = 0; i < RARCEntryHeader.DirectoryFileNum + RARCEntryHeader.TotalDirectoryCount + 1; i++) 
            {
                Debug.WriteLine(BinarySystem.ReadStringNullEnd(br));
            }
            BinarySystem.PaddingSkip(br.BaseStream);
            Debug.WriteLine("StringTableSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            foreach (FileNode fileNode in FileNodes) 
            {
                if (!((fileNode.FileType & RARCFileNodeType.File) == RARCFileNodeType.File))continue;
                br.ReadBytes(fileNode.Argments.Item2);
                
                BinarySystem.PaddingSkip(br.BaseStream);
                Debug.WriteLine("FileEnd::" + br.BaseStream.Position.ToString("X"));
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
