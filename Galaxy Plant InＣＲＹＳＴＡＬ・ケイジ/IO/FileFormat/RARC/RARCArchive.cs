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
        //public Dictionary<string, byte[]> FileKeyValuePairs{ get; private set; }

        private Stream _stream;

        private long stringDataTablePosition;

        public RARCArchive(Stream stream) 
        {
            stream = stream ?? throw new ArgumentNullException(nameof(stream));
            if (!stream.CanRead) throw new ArgumentException("このストリームは読み取りが出来ないかストリームが終了しています。");

            _stream = stream;
            using BinaryReader br = new(_stream);
            RARCHeader = new(br);
            RARCEntryHeader = new(br);

            DirectoryNodes = ReadDirectoryNodeSection(br);

            //各DirectoryNodeに含まれるRARCEntriesをセットします。
            for (int dirNodeIndex = 0; dirNodeIndex < DirectoryNodes.Length; dirNodeIndex++) 
            {
                DirectoryNodes[dirNodeIndex].RARCEntries = ReadRARCEntries(br,DirectoryNodes[dirNodeIndex].FolderDirectoryCount);
            }
            BinarySystem.PaddingSkip(br.BaseStream);
            

            //String Table
            stringDataTablePosition = br.BaseStream.Position;
            br.ReadBytes(RARCEntryHeader.StringTableLength);
            Debug.WriteLine("StringTableSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            //FileDataSection
            //FileKeyValuePairs = new Dictionary<string, byte[]>();
            foreach (DirectoryNode directoryNode in DirectoryNodes)
            {
                string dirPath = string.Empty;
                foreach (RARCEntry rarcEntry in directoryNode.RARCEntries)
                {
                    //ファイルデータの取得
                    Debug.WriteLine((RARCEntryType)rarcEntry.EntryType);
                    if ((rarcEntry.EntryType & RARCEntryType.File) == RARCEntryType.File)
                    {
                        byte[] fileBinaryData = br.ReadBytes((int)rarcEntry.Argments.Item2);
                        BinarySystem.PaddingSkip(br.BaseStream);
                        Debug.WriteLine("FileEnd::" + br.BaseStream.Position.ToString("X"));
                        
                        string fileName = BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + rarcEntry.NameOffset);

                        Debug.WriteLine(fileName);
                        //ファイルのデータを格納
                        //FileKeyValuePairs.Add(fileName, fileBinaryData);
                        directoryNode.IncludeFileNameBinaryPairs.Add(fileName, fileBinaryData);
                    }
                    else if ((rarcEntry.EntryType & RARCEntryType.Directory) == RARCEntryType.Directory)
                    {
                        string dirName = BinarySystem.ReadSeekStringNullEndAndSeekFix(br,stringDataTablePosition + rarcEntry.NameOffset);

                        if (dirName == ".")
                        {
                            directoryNode.CurrentDirectoryName = BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + directoryNode.DirectoryNameOffset);
                            Debug.WriteLine("CurrentDirectoryName::" + directoryNode.CurrentDirectoryName);
                        }
                        else if (dirName == "..")
                        {
                            //親ディレクトリがルートディレクトリのケース
                            if (rarcEntry.Argments.Item1 == 0xFFFFFFFF)
                            {
                                directoryNode.ParentDirectoryName = "ROOT";
                                Debug.WriteLine("ParentDirectoryName::" + directoryNode.ParentDirectoryName);
                                continue;
                            }
                            directoryNode.ParentDirectoryName = BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + rarcEntry.Argments.Item1);
                            Debug.WriteLine("ParentDirectoryName::" + directoryNode.ParentDirectoryName);
                        }
                        else 
                        {
                            //string subDir = BinarySystem.ReadSeekStringNullEndAndSeekFix(br, stringDataTablePosition + rarcEntry.Argments.Item1);
                            directoryNode.SubDirectories.Add(dirName);
                            Debug.WriteLine("SubDirectoryName::" + dirName);
                        }
                    }
                    else
                    {
                        throw new DataMisalignedException("このRARCファイルは、ファイルエントリセクションのRARCEntryTypeが壊れています。");
                        Application.Exit();
                    }
                }
            }

            
        }

        private DirectoryNode[] ReadDirectoryNodeSection(BinaryReader br) 
        {
            //DirectoryNodeSection
            DirectoryNode[] directoryNodes = new DirectoryNode[RARCEntryHeader.NodeLength];
            for (int entryIndex = 0; entryIndex < RARCEntryHeader.NodeLength; entryIndex++)
            {
                directoryNodes[entryIndex] = DirectoryNode.Read(br);
            }
            BinarySystem.PaddingSkip(br.BaseStream);
            Debug.WriteLine("DirectoryNodeSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            return directoryNodes;
        }

        private List<RARCEntry> ReadRARCEntries(BinaryReader br) 
        {
            //FileNodeSection
            List<RARCEntry> rarcEntries = new();
            for (int entryIndex = 0; entryIndex < RARCEntryHeader.TotalDirectoryCount; entryIndex++) 
            {
                rarcEntries.Add(new RARCEntry(br));
                //Debug.WriteLine(rarcEntries[entryIndex].NameOffset.ToString("X"));
            }
            BinarySystem.PaddingSkip(br.BaseStream);
            Debug.WriteLine("FileNodeSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            return rarcEntries;
        }

        private  List<RARCEntry> ReadRARCEntries(BinaryReader br,short folderDirectoryCount)
        {
            //FileNodeSection
            List<RARCEntry> rarcEntries = new();
            for (int entryIndex = 0; entryIndex < folderDirectoryCount; entryIndex++)
            {
                rarcEntries.Add(new RARCEntry(br));
                //Debug.WriteLine(rarcEntries[entryIndex].NameOffset.ToString("X"));
            }
            //BinarySystem.PaddingSkip(br.BaseStream);
            Debug.WriteLine("FileNodeSection EndPosition: " + br.BaseStream.Position.ToString("X"));

            return rarcEntries;
        }

        //public RARCArchiveEntry CreateEntry(string entryName) 
        //{
        //    throw new NotImplementedException();
        //}

        //public RARCArchiveEntry? GetEntry(string entryName) 
        //{
        //    throw new NotImplementedException();
        //}

        public void Dispose()
        {
            _stream.Close();
        }
    }
}
